using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FurnitureCompany.Controllers
{
    [Route("ManagerAssign")]
    [ApiController]
    public class AssignController : ControllerBase
    {
        private IAssignRepository iAssignRepository;
        private IManagerRepository iManagerRepository;
        public AssignController(IAssignRepository iAssignRepository,IManagerRepository iManagerRepository)
        {
            this.iAssignRepository = iAssignRepository;
            this.iManagerRepository = iManagerRepository;
        }
        // GET: api/<AssignController>
        [HttpGet]
        [Route("GetAllAssign")]
        public IActionResult GetAllAsign()
        {
            List<Assign> list = iAssignRepository.getAllAssign();
            return Ok(list);
        }

        // GET api/<AssignController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AssignController>
        [HttpPost]
        [Route("CreateAssignByManager/orderId/{id}")]
        public void createAssignByManager(AssignDto assignDto, int id)
        {
            Assign assign = new Assign()
            {
                OrderId = id,
                ManagerId = assignDto.ManagerId,
                EmployeeId = assignDto.EmployeeId,
                CreateAssignAt = DateTime.Now,
            };
            iAssignRepository.createAssign(assign);
            Order order = iManagerRepository.findandUpdateOrderStatusByManager(id);
            order.WorkingStatusId = 2;
            iManagerRepository.updateOrderStatus(order);
        }

        // PUT api/<AssignController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AssignController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
