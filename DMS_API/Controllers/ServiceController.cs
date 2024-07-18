using AutoMapper;
using DMS_API.Models.Domain;
using DMS_API.Models.DTO;
using DMS_API.Models.DTO.Request;
using DMS_API.Repository;
using DMS_API.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServiceController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            var services = await _unitOfWork.Services.GetAllServicesAsync();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById(Guid id)
        {
            var service = await _unitOfWork.Services.GetServiceById(id);
            if (service == null)
            {
                return NotFound(new { message = "Service not found" });
            }
            return Ok(service);
        }

        [HttpPost]
        public async Task<IActionResult> AddService([FromBody] AddServiceRequestDTO request)
        {
            var service = _mapper.Map<Service>(request);
            service.Id = Guid.NewGuid();

            await _unitOfWork.Services.AddAsync(service);
            await _unitOfWork.SaveChanges();
            return CreatedAtAction(nameof(GetServiceById), new { id = service.Id }, service);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(Guid id, [FromBody] UpdateServiceRequestDTO request)
        {
            var existingService = await _unitOfWork.Services.GetServiceById(id);
            if (existingService == null)
            {
                return NotFound(new { message = "Service not found" });
            }

            _mapper.Map(request, existingService);
            await _unitOfWork.Services.UpdateService(id, existingService);
            await _unitOfWork.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(Guid id)
        {
            var service = await _unitOfWork.Services.GetServiceById(id);
            if (service == null)
            {
                return NotFound(new { message = "Service not found" });
            }

            _unitOfWork.Services.Delete(service);
            return NoContent();
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

            var bookingService = _mapper.Map<BookingService>(request);
            bookingService.BookingId = bookingId;
            bookingService.Service = service;
            bookingService.Booking = booking;

            await _unitOfWork.Services.AddServiceRequestAsync(bookingService);
            user.Balance.Amount -= service.Price; 
            await _unitOfWork.Balances.UpdateBalanceAsync(user.Balance);
            await _unitOfWork.SaveChanges();

           
            var updatedBookingService = await _unitOfWork.Services.GetBookingServicesAsync(bookingId, request.ServiceId);
            var latestBookingService = updatedBookingService.FirstOrDefault(); 

            var bookingServiceDto = _mapper.Map<BookingServiceDTO>(latestBookingService);
            return Ok(bookingServiceDto);
        }


        [HttpGet("all-service-requests")]
        public async Task<IActionResult> GetAllServiceRequests()
        {
            var serviceRequests = await _unitOfWork.Services.GetAllServiceRequestsAsync();
            var serviceRequestDtos = _mapper.Map<IEnumerable<BookingServiceDTO>>(serviceRequests);
            return Ok(serviceRequestDtos);
        }

        [HttpGet("service-request/{id}")]
        public async Task<IActionResult> GetServiceRequestById(int id)
        {
            var serviceRequest = await _unitOfWork.Services.GetServiceRequestByIdAsync(id);
            if (serviceRequest == null)
            {
                return NotFound("Service request not found");
            }

            var serviceRequestDto = _mapper.Map<BookingServiceDTO>(serviceRequest);
            return Ok(serviceRequestDto);
        }
    }
}
