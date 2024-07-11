using Microsoft.AspNetCore.Mvc;
using DMS_API.Models.Domain;
using DMS_API.Models.DTO.Request;
using DMS_API.Models.DTO;
using DMS_API.Repository.Interface;
using AutoMapper;
using System;
using System.Threading.Tasks;
using OfficeOpenXml;
using static System.Net.WebRequestMethods;
using DMS_API.Services;
using Microsoft.AspNetCore.Identity;

namespace DMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public BookingController(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingRequestDTO request)
        {
            var user = await _unitOfWork.Users.GetUserByIdAsync(request.UserId);
            if (user == null) return NotFound("User not found");

            var room = await _unitOfWork.Rooms.GetByIdAsync(request.RoomId);
            if (room == null) return NotFound("Room not found");

            if (room.Capacity <= 0) return BadRequest("Room is fully booked");

            var totalPrice = room.Price; // Use the room price directly

            if (user.Balance == null) return BadRequest("User balance not found");

            if (user.Balance.Amount < totalPrice) return BadRequest("Insufficient balance");

            // Check if the user already has an approved booking
            var existingBooking = await _unitOfWork.Bookings.GetByUserIdAsync(user.Id);
            if (existingBooking != null && existingBooking.Status == "approved")
            {
                return BadRequest("User already has an approved booking and cannot book another room.");
            }

            var booking = _mapper.Map<Booking>(request);
            booking.Id = Guid.NewGuid();
            booking.BookingDate = DateTime.UtcNow;
            booking.StartDate = DateTime.UtcNow;
            booking.EndDate = DateTime.UtcNow.AddMonths(4); // Booking duration is 4 months
            booking.TotalPrice = totalPrice;
            booking.Status = "pending";

            await _unitOfWork.Bookings.AddAsync(booking);
            await _unitOfWork.SaveChanges();

            var bookingDto = _mapper.Map<BookingDTO>(booking);
            return Ok(bookingDto);
        }

        [HttpPut("{id}/approve")]
        public async Task<IActionResult> ApproveBooking(Guid id)
        {
            var booking = await _unitOfWork.Bookings.GetByIdAsync(id);
            if (booking == null) return NotFound("Booking not found");

            var user = await _unitOfWork.Users.GetUserByIdAsync(booking.UserId);
            if (user == null) return NotFound("User not found");

            if (user.Balance == null) return BadRequest("User balance not found");

            if (user.Balance.Amount < booking.TotalPrice) return BadRequest("Insufficient balance");

            var room = await _unitOfWork.Rooms.GetByIdAsync(booking.RoomId);
            if (room == null) return NotFound("Room not found");

            if (room.Capacity <= 0) return BadRequest("Room is fully booked");

            booking.Status = "approved";
            user.Balance.Amount -= booking.TotalPrice;
            room.Capacity -= 1;

            var updateBookingRequest = _mapper.Map<UpdateBookingRequestDTO>(booking);
            await _unitOfWork.Bookings.UpdateAsync(booking.Id, updateBookingRequest);

            await _unitOfWork.Balances.UpdateBalanceAsync(user.Balance);
            await _unitOfWork.Rooms.UpdateAsync(room.Id, new UpdateRoomRequestDTO
            {
                Name = room.Name,
                Status = room.Status,
                Description = room.Description,
                Capacity = room.Capacity,
                RoomType = room.RoomType,
                Price = room.Price
            });

            await _unitOfWork.SaveChanges();
            // Send OTP via email
            await _emailService.SendEmailAsync(user.Email,
                "Booking is approved", $"Your booking is approved please go the the web to see your room.");


            var bookingDto = _mapper.Map<BookingDTO>(booking);
            return Ok(bookingDto);
        }

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelBooking(Guid id)
        {
            var booking = await _unitOfWork.Bookings.GetByIdAsync(id);
            if (booking == null) return NotFound("Booking not found");

            if (booking.Status == "canceled") return BadRequest("Booking is already canceled");

            var user = await _unitOfWork.Users.GetUserByIdAsync(booking.UserId);
            if (user == null) return NotFound("User not found");

            var room = await _unitOfWork.Rooms.GetByIdAsync(booking.RoomId);
            if (room == null) return NotFound("Room not found");

            booking.Status = "canceled";
            user.Balance.Amount += booking.TotalPrice;

            var updateBookingRequest = _mapper.Map<UpdateBookingRequestDTO>(booking);
            await _unitOfWork.Bookings.UpdateAsync(booking.Id, updateBookingRequest);

            await _unitOfWork.Balances.UpdateBalanceAsync(user.Balance);
            await _unitOfWork.Rooms.UpdateAsync(room.Id, new UpdateRoomRequestDTO
            {
                Name = room.Name,
                Status = room.Status,
                Description = room.Description,
                Capacity = room.Capacity,
                RoomType = room.RoomType,
                Price = room.Price
            });

            await _unitOfWork.SaveChanges();

            var bookingDto = _mapper.Map<BookingDTO>(booking);
            return Ok(bookingDto);
        }

        [HttpGet("/get/{id}")]
        public async Task<IActionResult> GetBooking(Guid id)
        {
            var booking = await _unitOfWork.Bookings.GetByIdAsync(id);
            if (booking == null) return NotFound("Booking not found");

            var bookingDto = _mapper.Map<BookingDTO>(booking);
            return Ok(bookingDto);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetBookingByUserId(Guid userId)
        {
            var booking = await _unitOfWork.Bookings.GetByUserIdAsync(userId);
            if (booking == null) return NotFound($"Booking by userId:{userId} not found");
            var bookingDto = _mapper.Map<BookingDTO>(booking);
            return Ok(bookingDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _unitOfWork.Bookings.GetAllAsync();
            var bookingDtos = _mapper.Map<BookingDTO[]>(bookings);
            return Ok(bookingDtos);
        }
    }
}
