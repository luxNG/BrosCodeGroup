using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.IService;
using FurnitureCompany.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FurnitureCompany.Controllers
{
    [Route("/api/customer/")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        
        private ICustomerRepository iCustomerRepository;
        private IOrderRepository iOrderRepository;
        private IOrderServiceRepository iOrderServiceRepository;
        private ICustomerService customerService;
        public CustomerController(ICustomerRepository iCustomerRepository, IOrderRepository iOrderRepository, IOrderServiceRepository iOrderServiceRepository, ICustomerService customerService)
        {

            this.iCustomerRepository = iCustomerRepository;
            this.iOrderRepository = iOrderRepository;
            this.iOrderServiceRepository = iOrderServiceRepository;
            this.customerService = customerService;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        [Route("getAllCustomer")]
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
        public IActionResult customerGetOrderDetailInformationByOrderId(int id)
        {
          
            try
            {
                CustomerGetDetailOrderInforDto orderDto = customerService.customerGetOrderDetailInformationByOrderId(id);
                return Ok(orderDto);
            }
            catch (Exception)
            {
                return NotFound("Can not found detail order information, try again. ");                
            }
        }

        //Chức năng: Customer xóa đơn hàng sau khi đã tạo 
        //Tham số đầu vào: customerId là id của customer - orderId là id của đơn hàng 
        // update status đơn hàng giá trị True => False
        [HttpPost]
        [Route("/Delete/Order/{id}")]
        public IActionResult DeleteOrderByCustomer(int id)
        {
            try
            {
                Order order = customerService.DeleteOrderByCustomer(id);
                return Ok(order);
            }
            catch (Exception)
            {
                return BadRequest("Can not delete your order, please try again");
            }
        }

       
    }
}
