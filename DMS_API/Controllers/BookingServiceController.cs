using System;
using System.Threading.Tasks;
using DMS_API.Models.Domain;
using DMS_API.Models.DTO.Request;
using DMS_API.Models.DTO;
using DMS_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DMS_API.Repository.Interface;

namespace DMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingServiceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public BookingServiceController(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
        }

        [HttpPost("{bookingId}/request-service")]
        public async Task<IActionResult> RequestService(Guid bookingId, [FromBody] ServiceRequestDTO request)
        {
            var booking = await _unitOfWork.Bookings.GetByIdAsync(bookingId);
            if (booking == null) return NotFound("Student must have an approved booking to request services");

            if (booking.Status != "approved")
            {
                return BadRequest("Student must have an approved booking to request services");
            }

            var user = await _unitOfWork.Users.GetUserByIdAsync(booking.UserId);
            if (user == null) return NotFound("Student not found");

            if (user.Balance == null) return BadRequest("Student balance not found");

            var service = await _unitOfWork.Services.GetServiceById(request.ServiceId);
            if (service == null) return NotFound("Service not found");

            if (user.Balance.Amount < service.Price)
            {
                return BadRequest("Insufficient balance to request this service");
            }

            // Deduct the balance immediately
            user.Balance.Amount -= service.Price;
            await _unitOfWork.Balances.UpdateBalanceAsync(user.Balance);

            BookingService bookingService = new BookingService
            {
                BookingId = bookingId,
                ServiceId = request.ServiceId,
                Service = service,
                Booking = booking,
                RequestDate = DateTime.UtcNow,
                Status = "pending"
            };

            await _unitOfWork.Services.AddServiceRequestAsync(bookingService);
            await _unitOfWork.SaveChanges(); // Ensure the changes are saved to the database

            return Ok("Wait for admin acceptance!");
        }

        [HttpGet("service-request/{bookingServiceid}")]
        public async Task<IActionResult> GetServiceRequestById(int bookingServiceid)
        {
            var serviceRequest = await _unitOfWork.Services.GetServiceRequestByIdAsync(bookingServiceid);
            if (serviceRequest == null)
            {
                return NotFound("Service request not found");
            }

            var serviceRequestDto = _mapper.Map<BookingServiceDTO>(serviceRequest);
            return Ok(serviceRequestDto);
        }

        [HttpPost("service-request/{bookingServiceid}/approve")]
        public async Task<IActionResult> ApproveServiceRequest(int bookingServiceid)
        {
            var serviceRequest = await _unitOfWork.Services.GetServiceRequestByIdAsync(bookingServiceid);
            if (serviceRequest == null)
            {
                return NotFound("Service request not found");
            }

            var booking = await _unitOfWork.Bookings.GetByIdAsync(serviceRequest.BookingId);
            var user = await _unitOfWork.Users.GetUserByIdAsync(booking.UserId);
            var service = await _unitOfWork.Services.GetServiceById(serviceRequest.ServiceId);

            serviceRequest.Status = "approved";
            await _unitOfWork.Services.UpdateService(service.Id, service);
            await _unitOfWork.SaveChanges(); // Ensure the changes are saved to the database

            var serviceRequestDto = _mapper.Map<BookingServiceDTO>(serviceRequest);
            return Ok(serviceRequestDto);
        }

        [HttpPost("service-request/{bookingServiceid}/cancel")]
        public async Task<IActionResult> CancelServiceRequest(int bookingServiceid, [FromBody] CancelRequestDTO cancelRequest)
        {
            var serviceRequest = await _unitOfWork.Services.GetServiceRequestByIdAsync(bookingServiceid);
            if (serviceRequest == null)
            {
                return NotFound("Service request not found");
            }

            if (serviceRequest.Status != "pending")
            {
                return BadRequest("Only pending service requests can be cancelled");
            }

            var booking = await _unitOfWork.Bookings.GetByIdAsync(serviceRequest.BookingId);
            var user = await _unitOfWork.Users.GetUserByIdAsync(booking.UserId);
            var service = await _unitOfWork.Services.GetServiceById(serviceRequest.ServiceId);

            // Refund the balance
            user.Balance.Amount += service.Price;
            await _unitOfWork.Balances.UpdateBalanceAsync(user.Balance);

            // Update service request status to cancelled
            serviceRequest.Status = "cancelled";
            await _unitOfWork.Services.UpdateService(service.Id, service);
            await _unitOfWork.SaveChanges(); // Ensure the changes are saved to the database

            // Send cancellation email
            var subject = "Service Request Cancelled";
            var message = $"Dear {user.UserName},\n\nYour service request has been cancelled for the following reason:\n\n{cancelRequest.Reason}\n\nBest regards,\nAdmin";
            await _emailService.SendEmailAsync(user.Email, subject, message);

            return Ok("Service request cancelled and balance refunded");
        }
    }
}
