using LeaveManagementSystemnew.Data;
using LeaveManagementSystemnew.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystemnew.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContextcs _context;

        public EmployeeController(AppDbContextcs context)
        {
            _context = context;
        }

        [HttpGet("GetAllEmployees")]
        public IActionResult GetEmployee()
        {

            return Ok(_context.Employees.ToList());
        }

        [HttpPost("AddEmployees")]
        public IActionResult AddEmployee(Employee emp)
        {
            _context.Employees.Add(emp);
            _context.SaveChanges();
            return Ok(emp);

        }
        [HttpPut("UpdateEmployee/{id}")]
        public IActionResult UpdateEmployee(int id,Employee emp)
        {
            Employee? getEmp = _context.Employees.Find(id);
            if (getEmp == null) return NotFound();

            getEmp.Name = emp.Name;
            getEmp.Email = emp.Email;
            getEmp.Role = emp.Role;

            _context.SaveChanges();

            return Ok(getEmp);//JSON is returned as Response
            

        }
        [HttpDelete("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id, Employee emp)
        {

            Employee? getEmp = _context.Employees.Find(id);
            if (getEmp == null) return NotFound();
            _context.Employees.Remove(getEmp);
            _context.SaveChanges();
            return Ok();
        }

    }
}
