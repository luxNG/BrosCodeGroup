using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.IService;
using FurnitureCompany.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FurnitureCompany.Controllers
{
    [Route("api/employeeDayOff/")]
    [ApiController]
    public class EmployeeDayOffController : ControllerBase
    {
        private IEmployeeDayOffRepository iEmployeeDayOffRepository;
        private IEmployeeDayOffService employeeDayOffService;
        public EmployeeDayOffController(IEmployeeDayOffRepository iEmployeeDayOffRepository, IEmployeeDayOffService employeeDayOffService)
        {

            this.iEmployeeDayOffRepository = iEmployeeDayOffRepository;
            this.employeeDayOffService = employeeDayOffService;
        }

        // GET: api/<EmployeeDayOffController>
        [HttpGet]
        [Route("getAllEmployeeDayOff/cai_nay_BE_test_ko_dung")]
        public IActionResult getAllEmployeeDayOff()
        {
            List<EmployeeDayOff> listEmployeeDayOff = iEmployeeDayOffRepository.getAllEmployeeDayOff();
            return Ok(listEmployeeDayOff);
        }

       
        

       

       
    }
}
