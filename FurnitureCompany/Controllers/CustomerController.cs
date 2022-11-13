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

       
        //Chức năng: Khách hàng tạo đơn hàng sau khi đã đăng nhập 
        //Với id là id của khách hàng sau khi đăng nhập
        [HttpPost("createOrder/customer/{id}")]
        public async Task<IActionResult> CreateOrderTestByCustomer(int id, CustomerFullOrderDto customerFullOrderDto)
        {
            Order order =  new Order()
            {
                CustomerId = id,
                Address = customerFullOrderDto.Address,
                WorkingStatusId = 1,
                TotalPrice = customerFullOrderDto.TotalPrice,
                CreateAt = DateTime.Now,
                Status = true,
                Description = customerFullOrderDto.Description
            };
            Order orderAfterAddtoDb = await iOrderRepository.CreateOrderAsync(order);
            if (orderAfterAddtoDb.OrderId != -1)
            {
              
                OrderService orderService = new OrderService()
                {
                    OrderId = orderAfterAddtoDb.OrderId,
                    ServiceId = customerFullOrderDto.ServiceId,
                    EstimateTimeFinish = "2 slot"
                };
                 iOrderServiceRepository.addOrderService(orderService);
            }

          /*  CustomerFullOrderDto c = new CustomerFullOrderDto()
            {
                Address = orderAfterAddtoDb.Address,
                TotalPrice = orderAfterAddtoDb.TotalPrice,
                Description = orderAfterAddtoDb.Description,
                WorkingStatusId = orderAfterAddtoDb.WorkingStatusId,
                ServiceId=customerFullOrderDto.ServiceId,


            };*/
            return Ok();
        }

        [HttpGet]
        [Route("/getOrderInformation/orderId/{id}")]
        public IActionResult GetOrderInformation(int id)
        {
            Order order = iOrderRepository.getOrderById(id);
            return Ok(order);
        }

        //Chức năng: Customer xóa đơn hàng sau khi đã tạo 
        //Tham số đầu vào: customerId là id của customer - orderId là id của đơn hàng 
        // update status đơn hàng giá trị True => False
        [HttpPost]
        [Route("/Delete/Order/{customerId}/{orderId}")]
        public IActionResult DeleteOrderByCustomer(int customerId, int orderId)
        {
            Order order = iOrderRepository.findOrderByOrderIdAndCustomerId(orderId, customerId);
            order.Status = false;
            iOrderRepository.updateOrder(order);
            return Ok(order.Status);                 
        }

       
    }
}
