using DMS_API.Models.Domain;
using DMS_API.Models.DTO.Request;

namespace DMS_API.Repository.Interface
{
    public interface IBookingRepository : IRepository<Booking> 
    {
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<Booking?> GetByIdAsync(Guid id);
        Task<Booking> GetByUserIdAsync(Guid userId);
        Task UpdateAsync(Guid id, UpdateBookingRequestDTO booking);
    }
}
