namespace EmployeeManagement.Api.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string NAME { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public string? ProfileImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
