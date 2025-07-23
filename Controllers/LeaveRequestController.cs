    using LeaveManagementSystemnew.Data;
    using LeaveManagementSystemnew.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    namespace LeaveManagementSystem.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class LeaveRequestController : ControllerBase 
        {
            private readonly AppDbContextcs _context;
            public LeaveRequestController(AppDbContextcs context) { 
         
                _context = context;
            }

            [HttpGet("GetAllLeaveRequests")]
            public IActionResult GetAllLeaveRequets()
            {
                var leaveRequests = _context.LeaveRequests.Include(l=>l.Employee).ToList();
                return Ok(leaveRequests);
            }

            [HttpPost("CreateLeaveRequest")]
            public IActionResult CreateLeaveRequet(LeaveRequest request)
            {
                request.Status = "pending"; 
                _context.LeaveRequests.Add(request);
                _context.SaveChanges();
                return Ok(request);
            }

            [HttpPut("approve/{id}")]
            public IActionResult ApproveLeaveRequest(int id)
            {
                var leaveRequest = _context.LeaveRequests.Find(id);
                if (leaveRequest == null)
                {
                    return NotFound();
                }
                leaveRequest.Status = "Approved";
                _context.SaveChanges();
                return Ok(leaveRequest);
            }

            [HttpPut("reject/{id}")]
            public IActionResult RejectLeaveRequest(int id)
            {
                var leaveRequest = _context.LeaveRequests.Find(id);
                if (leaveRequest == null)
                {
                    return NotFound();
                }
                leaveRequest.Status = "Rejected";
                _context.SaveChanges();
                return Ok(leaveRequest);
            }
        }
    }
