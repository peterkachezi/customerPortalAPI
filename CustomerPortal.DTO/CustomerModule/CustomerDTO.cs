

namespace CustomerPortal.DTO.CustomerModule
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public int? MaritalStatus { get; set; }
        public byte[]? CustomerPhoto { get; set; }

    }
}
