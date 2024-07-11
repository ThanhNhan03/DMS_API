namespace DMS_API.Models.DTO
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string OrderReference { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; } = "pending";
        public float Amount { get; set; }
    }
}
