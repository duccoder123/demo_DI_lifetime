using demo_DI.Context;
using demo_DI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo_DI.Controllers
{
    [Authorize(Policy ="RequirAdminRole")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Create a new employee after trigger will automatically update the number of employees
        /// </summary>
        /// <returns>204 No Content</returns>

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDetail>>> GetEmployeeDetails()
        {
            var employeeDetails = await _context.EmployeeDetails
                                    .FromSQ("SELECT * FROM EmployeeDetails")
                                    .ToListAsync();

            return Ok(employeeDetails);
        }
    }
}
