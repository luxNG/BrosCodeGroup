using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
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
        public ManagerController(IManagerRepository iManagerRepository)
        {

            this.iManagerRepository = iManagerRepository;
        }

        // GET: api/<ManagerController>
        [HttpGet]
        [Route("GetAllOrder")]
        public IActionResult GetOrderByManager()
        {
            List<Order> list = iManagerRepository.getAllOrder();
            return Ok(list);
        }

        // GET api/<ManagerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ManagerController>
       /* [HttpPost]
        [Route("assignEmployee")]
        public void PostAssign()
        {
            
           
        }*/

        // PUT api/<ManagerController>
        // cập nhật đơn hàng thành trạng thái đã hoàn thành
        [HttpPut("updateOrderStatusDone/{id}")]
        public void Put(int orderId)
        {
            Order order =  iManagerRepository.findandUpdateOrderStatusByManager(orderId);
            order.WorkingStatusId = 6;
            iManagerRepository.updateOrderStatus(order);
        }


        [HttpPut("updateTotalPrice/order/{id}")]
        public void updateTotalPriceByManager(int orderId, OrderDto orderDto)
        {
            Order order = iManagerRepository.findandUpdateTotalPrice(orderId);
            order.TotalPrice = orderDto.TotalPrice;
            iManagerRepository.updateTotalPriceByManager(order);
        }


        // DELETE api/<ManagerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
