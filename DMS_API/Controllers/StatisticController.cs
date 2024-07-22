using AutoMapper;
using DMS_API.Models.Domain;
using DMS_API.Repository;
using DMS_API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public StatisticController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet("approved-bookings/count")]
        public async Task<IActionResult> GetApprovedBookingsCount()
        {
            var approvedBookings = await _unitOfWork.Bookings.GetAllApprovedBookingsAsync();
            var count = approvedBookings.Count();
            return Ok(new { totalApprovedBookings = count });
        }

        [HttpGet("booking-requests/count")]
        public async Task<IActionResult> GetBookingRequestsCount()
        {
            var bookingRequests = await _unitOfWork.Bookings.GetBookingRequestsCountAsync();
            var count = bookingRequests.Count();
            return Ok(new { totalBookingRequests = count });
        }


        [HttpGet("service-usage-percentage")]
        public async Task<IActionResult> GetServiceUsagePercentage()
        {
            var serviceRequests = await _unitOfWork.Services.GetAllServiceRequestsAsync();
            var totalUsageCount = serviceRequests.Sum(sr => sr.UsageCount);
            if (totalUsageCount == 0)
            {
                return Ok("No service requests found.");
            }

            var serviceUsage = serviceRequests
                .GroupBy(sr => sr.ServiceId)
                .Select(g => new
                {
                    ServiceId = g.Key,
                    ServiceName = g.First().Service.ServiceName,
                    UsagePercentage = (double)g.Sum(sr => sr.UsageCount) / totalUsageCount * 100
                })
                .OrderByDescending(s => s.UsagePercentage)
                .ToList();

            return Ok(serviceUsage);
        }


        [HttpGet("service-request/count")]
        public async Task<IActionResult> GetApprovedServiceRequestCount()
        {
            var count = await _unitOfWork.Services.GetAllPendingServiceRequestsAsync();
            var totalRequests = count.Count();
            return Ok(new { totalServiceRequests = totalRequests });
        }

        [HttpGet("monthly-revenue")]
        public async Task<IActionResult> GetMonthlyRevenue()
        {
            var approvedBookings = await _unitOfWork.Bookings.GetAllApprovedBookingsAsync();
            var approvedServiceRequests = await _unitOfWork.Services.GetAllApprovedServiceRequests();

            // Group bookings and services by month
            var monthlyBookingsRevenue = approvedBookings
                .GroupBy(b => b.BookingDate.Month)
                .Select(g => new
                {
                    Month = g.Key,
                    TotalRevenue = g.Sum(b => b.Room.Price)
                })
                .ToList();

            var monthlyServicesRevenue = approvedServiceRequests
                .GroupBy(s => s.RequestDate.Month)
                .Select(g => new
                {
                    Month = g.Key,
                    TotalRevenue = g.Sum(s => s.Service.Price)
                })
                .ToList();

            // Combine booking and service revenues
            var monthlyRevenue = monthlyBookingsRevenue
                .Union(monthlyServicesRevenue)
                .GroupBy(r => r.Month)
                .Select(g => new
                {
                    Month = g.Key,
                    TotalRevenue = g.Sum(r => r.TotalRevenue)
                })
                .OrderBy(r => r.Month)
                .ToList();

            return Ok(monthlyRevenue);
        }


    }
}


