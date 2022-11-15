using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.IService;
using FurnitureCompany.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FurnitureCompany.Controllers
{
    [Route("api/manager")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private IManagerRepository iManagerRepository;
        private ICategoryRepository iCategoryRepository;
        private IManagerService managerService;
        public ManagerController(IManagerRepository iManagerRepository, ICategoryRepository iCategoryRepository, IManagerService managerService)
        {

            this.iManagerRepository = iManagerRepository;
            this.iCategoryRepository = iCategoryRepository;
            this.managerService = managerService;
        }

        // GET: api/<ManagerController>
        [HttpGet]
        [Route("GetAllOrder")]
        public IActionResult getOrderByManager()
        {           
            try
            {
                List<Order> list = managerService.getOrderByManager();
                return Ok(list);
            }
            catch (Exception)
            {
                return BadRequest("Can not get all order information ");
            }
        }

        // GET api/<ManagerController>/5
        [HttpGet]
        [Route("ManagerGetAllCategory")]
        public IActionResult getAllCategory()
        {
            try
            {
                List<Category> list = managerService.getAllCategoryByManager();
                return Ok(list);
            }
            catch (Exception)
            {

                return BadRequest("Can not get category information ");
            }
        }

        // POST api/<ManagerController>
        [HttpPost]
        [Route("assignEmployee")]
        public void PostAssign()
        {


        }

        // PUT api/<ManagerController>
        // cập nhật đơn hàng thành trạng thái đã hoàn thành
        [HttpPut("updateOrderStatusDone/{id}")]
        public IActionResult updateOrderStatusDoneByManager(int id)
        {
            try
            {
                Order order = managerService.updateOrderStatusDoneByManager(id);
                return Ok(order);
            }
            catch (Exception)
            {

                return BadRequest("Can not update order status DONE, try again. ");
            }
        }


        [HttpPut("updateTotalPrice/order/{id}")]
        public IActionResult updateTotalPriceByManager(int id, OrderDto orderDto)
        {
            try
            {
                Order order = managerService.updateTotalPriceByManager(id, orderDto);
                return Ok(order);
            }
            catch (Exception)
            {
                return BadRequest("Can not update total price by manager, try again. ");
            }
        }

        [HttpGet]
        [Route("api/getOrderByOrderId/{id}")]
        public IActionResult managerGetOrderByOrderId(int id)
        {
            try
            {
                Order order = managerService.managerGetOrderByOrderId(id);
                return Ok(order);
            }
            catch (Exception)
            {
                return NotFound("Can not found order information try agian. ");                
            }
        }

    }
}
