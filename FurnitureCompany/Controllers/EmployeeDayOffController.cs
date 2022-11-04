using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FurnitureCompany.Controllers
{
    [Route("api/employeeDayOff")]
    [ApiController]
    public class EmployeeDayOffController : ControllerBase
    {
        private IEmployeeDayOffRepository iEmployeeDayOffRepository;
        public EmployeeDayOffController(IEmployeeDayOffRepository iEmployeeDayOffRepository)
        {

            this.iEmployeeDayOffRepository = iEmployeeDayOffRepository;
        }

        // GET: api/<EmployeeDayOffController>
        [HttpGet]
        [Route("getAllEmployeeDayOff")]
        public IActionResult getAllEmployeeDayOff()
        {
            List<EmployeeDayOff> listEmployeeDayOff = iEmployeeDayOffRepository.getAllEmployeeDayOff();
            return Ok(listEmployeeDayOff);
        }

        // GET api/<EmployeeDayOffController>/5
        [HttpGet("getDayOffByEmployeeId/{id}")]
        public IActionResult getDayOffByEmployeeId(int id)
        {
            EmployeeDayOff e = iEmployeeDayOffRepository.getEmployeeDayOffByEmployeeId(id);
            return Ok(e);
        }

        // GET api/<EmployeeDayOffController>/5
      /*  [HttpGet("getDayOffByEmployeeIdTest/{id}")]
        public IActionResult getDayOffByEmployeeIdTest(int id)
        {
            Employee e = iEmployeeDayOffRepository.getEmployeeDayOffByEmployeeIdTest(id);
            return Ok(e);
        }*/

        // POST api/<EmployeeDayOffController>
        [HttpPost]
        [Route("EmployeeFormForAbsent")]
        public void Post(EmployeeDayOffDto employeeDayOffDto)
        {
            EmployeeDayOff employeeDayOff = new EmployeeDayOff()
            {
                EmployeeId = employeeDayOffDto.EmployeeId,
                Reason = employeeDayOffDto.Reason,
                // sau này khi đã kết nối với mobile
                // thì chuyển lại thành giờ để test local " employeeDayOffDto.DayOff"
                DayOff = DateTime.Now, 
            };
            iEmployeeDayOffRepository.employeeTakeDayOff(employeeDayOff);
        }

        // PUT api/<EmployeeDayOffController>/5
        [HttpPut("{id}")]
        public void Put(int id)
        {

        }

        // DELETE api/<EmployeeDayOffController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            EmployeeDayOff e = iEmployeeDayOffRepository.getDayOffIdByEmployee(id);
            iEmployeeDayOffRepository.deleteDayOffByEmployee(e);
        }
    }
}
