namespace LeaveManagementSystemnew.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public ICollection<LeaveRequest>? LeaveRequests { get; set; }

        public Employee()
        {
            if (Name == null)
            {
                Name = "";
            }
            if (Role == null)
            {
                Role = "";
            }

            if (Email == null)
            {
                Email = "";
            }


        }
    }
}
