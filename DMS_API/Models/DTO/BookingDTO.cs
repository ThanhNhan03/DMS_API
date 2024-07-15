using DMS_API.Models.Domain;

namespace DMS_API.Models.DTO
{
    public class BookingDTO
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public string RoomName { get; set; }
        public string UserName { get; set; }
        public string RoomType { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float TotalPrice { get; set; }
        public string Status { get; set; }
        public HouseDTO? House { get; set; }

    }
}
