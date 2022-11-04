using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FurnitureCompany.Controllers
{
    [Route("customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        
        private ICustomerRepository iCustomerRepository;
        private IOrderRepository iOrderRepository;
        private IOrderServiceRepository iOrderServiceRepository;
        public CustomerController(ICustomerRepository iCustomerRepository, IOrderRepository iOrderRepository, IOrderServiceRepository iOrderServiceRepository)
        {

            this.iCustomerRepository = iCustomerRepository;
            this.iOrderRepository = iOrderRepository;
            this.iOrderServiceRepository = iOrderServiceRepository;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        [Route("/getAllCustomer")]
        public IActionResult GetAllCustomerInfomation()
        {
            List<Customer> listCustomer = iCustomerRepository.getAllCustomer();
            return Ok(listCustomer);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            Customer customer = iCustomerRepository.getCustomerById(id);
            if(customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // POST api/<CustomerController>
        /*  [HttpPost]
          public void Post([FromBody] string value)
          {
          }*/

        // POST api/<CustomerController> Tạo đơn hàng dành cho customer sau khi đã đăng nhập
        /*[HttpPost("createOrder/customer/{id}")]
        public void CreateOrderByCustomer(int id, OrderDto orderDto, OrderServiceDto orderServiceDto)
        {
            Order order = new Order()
            {
                CustomerId = id,
                Address = orderDto.Address,
                WorkingStatusId = 1,
                TotalPrice = orderDto.TotalPrice,
                CreateAt = DateTime.Now,
                Status = true,
                Description = orderDto.Description
            };
            OrderService orderService = new OrderService()
            {
                OrderId = order.OrderId,
                OrderServiceId = orderServiceDto.OrderServiceId,
                EstimateTimeFinish = "2 slot"
            };

            iOrderRepository.createOrder(order);
            iOrderServiceRepository.addOrderService(orderService);
        }*/

        [HttpPost("createOrder/customer/{id}")]
        public void CreateOrderTestByCustomer(int id, CustomerFullOrderDto customerFullOrderDto)
        {
            Order order = new Order()
            {
                CustomerId = id,
                Address = customerFullOrderDto.Address,
                WorkingStatusId = 1,
                TotalPrice = customerFullOrderDto.TotalPrice,
                CreateAt = DateTime.Now,
                Status = true,
                Description = customerFullOrderDto.Description
            };
            OrderService orderService = new OrderService()
            {
                OrderId = order.OrderId,
                ServiceId = customerFullOrderDto.ServiceId,
                EstimateTimeFinish = "2 slot"
            };
            iOrderRepository.createOrder(order);
            iOrderServiceRepository.addOrderService(orderService);
        }

        [HttpGet]
        [Route("/getOrderInformation/orderId/{id}")]
        public IActionResult GetOrderInformation(int id)
        {
            Order order = iOrderRepository.getOrderById(id);
            return Ok(order);
        }

        // DELETE api/<CustomerController>/5
        /* [HttpDelete("{id}")]
         public void Delete(int id)
         {
         }*/
    }
}
