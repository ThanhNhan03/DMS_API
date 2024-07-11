using DMS_API.Models.Domain;
using DMS_API.Models.DTO.Request;

namespace DMS_API.Repository.Interface
{
    public interface IBookingRepository : IRepository<Booking> 
    {
        Task<Booking?> GetByIdAsync(Guid id);
        Task UpdateAsync(Guid id, UpdateBookingRequestDTO booking);
        Task<IEnumerable<Booking?>> GetAllAsync();
        Task<Booking?> GetByUserIdAsync(Guid userId);
    }
}
