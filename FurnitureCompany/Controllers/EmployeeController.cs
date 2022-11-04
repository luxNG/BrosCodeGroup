using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FurnitureCompany.Controllers
{
    [Route("employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository iEmployeeRepository;
        private IAssignRepository iAssignRepository;
        public EmployeeController(IEmployeeRepository iEmployeeRepository, IAssignRepository iAssignRepository)
        {

            this.iEmployeeRepository = iEmployeeRepository;
            this.iAssignRepository = iAssignRepository;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        [Route("/getAllEmployee")]
        public IActionResult GetAllEmployeeInformation()
        {
           List<Employee> employeeList = iEmployeeRepository.getAllEmployee();
            return Ok(employeeList);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("/{id}")]
        public IActionResult GetEmployeeId(int id)
        {
            Employee e =iEmployeeRepository.getEmployeeById(id);
            if (e == null)
            {
                return  BadRequest();
            }
            return Ok(e);
            
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post(EmployeeDto employeeDto)
        {
            Employee e = new Employee()
            {
                AccountId = 1,
                SpecialtyId = 1,
                EmployeeName = employeeDto.EmployeeName,
                Email = employeeDto.Email,
                EmployeePhoneNumber = employeeDto.EmployeePhoneNumber,
                WorkingStatus = false,
                Status = true
            };
            iEmployeeRepository.addNewEmployee(e);
            return Ok();
                 
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("employeeUpdateAvatar/{id}")]
        public IActionResult UpdateEmployeeAvatar(int id, string newAvatarUrl)
        {
            Employee e = iEmployeeRepository.getEmployeeById(id);
            e.ImageUrl = newAvatarUrl;
            iEmployeeRepository.updateEmployeeUrlImage(e);
           
            return Ok(e + " Update image success");
        }

        [HttpPut("emplooyeeUpdateInformation/{id}")]
        public IActionResult UpdateEmployeeInformation(int id, EmployeeDto employeeDto)
        {
            Employee e = iEmployeeRepository.getEmployeeById(id);
            e.Email = employeeDto.Email;
            iEmployeeRepository.updateEmployeeUrlImage(e);
            return Ok(e + " Update Email Success");
        }

        [HttpPut("updateEmployeeStatus/{id}")]
        public IActionResult UpdateEmployeeStatus(int id, bool workStatus)
        {
            Employee e = iEmployeeRepository.getEmployeeById(id);
            e.WorkingStatus = workStatus;
            iEmployeeRepository.updateEmployeeUrlImage(e);
            return Ok(e + " Update working status success ");
        }

        [HttpGet]
        [Route("ViewAssign/employeeId/{id}")]
        public IActionResult viewAssign(int id)
        {
            List<Assign> assign = iAssignRepository.getAllAssignByEmployeeId(id);
            return Ok(assign);
        }


    }
}
