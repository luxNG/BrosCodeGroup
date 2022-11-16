using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.IService;
using FurnitureCompany.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FurnitureCompany.Controllers
{
    [Route("api/assign/")]
    [ApiController]
    public class AssignController : ControllerBase
    {
        private IAssignRepository iAssignRepository;
        private IManagerRepository iManagerRepository;
        private IAssignService assignService;
        public AssignController(IAssignRepository iAssignRepository,IManagerRepository iManagerRepository, IAssignService assignService)
        {
            this.iAssignRepository = iAssignRepository;
            this.iManagerRepository = iManagerRepository;
            this.assignService = assignService;
        }
        // GET: api/<AssignController>
        [HttpGet]
        [Route("manager/getAllAssign")]
        public IActionResult managerGetAllAssign()
        {
            try
            {
                List<Assign> listAssign = assignService.managerGetAllAssign();
                return Ok(listAssign);
            }
            catch (Exception)
            {
                return BadRequest("Can not get assign information ");
            }
            
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
        public void createAssignByManager(int id, ManagerAssignDto assignDto)
        {

            foreach (var item in assignDto.listEmployee)
            {
                Assign assign = new Assign()
                {
                    OrderId = id,
                    ManagerId = assignDto.ManagerId,
                    EmployeeId = item.EmployeeId,
                    CreateAssignAt = assignDto.CreateAssignAt,
                    Status = true,
                };
                iAssignRepository.createAssign(assign);
            }
             
            Order order = iManagerRepository.findandUpdateOrderStatusByManager(id);
            order.WorkingStatusId = 2;
            iManagerRepository.updateOrderStatus(order);
        }

        // PUT api/<AssignController>/5
        [HttpPut]
        [Route("manager/updateassignstatus/byassignid/{id}")]
        public IActionResult managerUpdateAssignStatusByAssignId(int id, AssignDto assignDto)
        {
            try
            {
                Assign assign = assignService.managerUpdateAssignStatusByAssignId(id, assignDto);
                return Ok(assign);
            }
            catch (Exception)
            {
                return BadRequest("Can not update assign status, try again");
            }
        }

        // DELETE api/<AssignController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
