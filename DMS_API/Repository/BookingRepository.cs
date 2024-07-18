﻿using DMS_API.DataAccess;
using DMS_API.Models.Domain;
using DMS_API.Models.DTO.Request;
using DMS_API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DMS_API.Repository
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public readonly ApplicationDbContext _context;
        public BookingRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Booking?> GetByIdAsync(Guid id)
        {
            return await _context.Bookings
               .Include(b => b.Room)
                .ThenInclude(r => r.House)
                 .ThenInclude(h => h.Floor)
                .ThenInclude(f => f.Dorm)
                .Include(b => b.User)
                .AsSplitQuery()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task UpdateAsync(Guid id, UpdateBookingRequestDTO booking)
        {
            var existingBooking = await GetByIdAsync(id);
            if (existingBooking == null)
            {
                throw new KeyNotFoundException("Booking not found");
            }

            existingBooking.RoomId = booking.RoomId;
            existingBooking.StartDate = booking.StartDate;
            existingBooking.EndDate = booking.EndDate;
            existingBooking.TotalPrice = booking.TotalPrice;
            existingBooking.Status = booking.Status;

            _context.Bookings.Attach(existingBooking);
            _context.Entry(existingBooking).State = EntityState.Modified;
        }


        public async Task<IEnumerable<Booking?>> GetAllAsync()
        {
            return await _context.Bookings
                .Include(b => b.Room)
                .ThenInclude(r => r.House)
                 .ThenInclude(h => h.Floor)
                .ThenInclude(f => f.Dorm)
                .Include(b => b.User)
                .AsSplitQuery()
                .ToListAsync();
        }
        public async Task<Booking?> GetByUserIdAsync(Guid userId)
        {
            return await _context.Bookings
                .Include(b => b.Room)
                .ThenInclude(r => r.House)
                 .ThenInclude(h => h.Floor)
                .ThenInclude(f => f.Dorm)
                .Include(b => b.User)
                .AsSplitQuery()
                .FirstOrDefaultAsync(b => b.UserId == userId);
        }

        public async Task<List<Booking>> GetAllBookingsOrderedByStartDateAsync()
        {
            var bookings = await _context.Bookings
                 .OrderByDescending(b => b.StartDate)
                 .ToListAsync();

            return bookings;
        }
    }
}
