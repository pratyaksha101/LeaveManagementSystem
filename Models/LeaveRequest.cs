using System.Text.Json.Serialization;

namespace LeaveManagementSystemnew.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public string Reason { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }

        [JsonIgnore]
        public Employee? Employee { get; set; }

        public LeaveRequest() { 
        
            if(Reason==null)
            {
                Reason = "";
            }
            if(Status==null)
            {
                Status = "";
            }
        }


    }
}
