using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.IService;
using FurnitureCompany.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FurnitureCompany.Controllers
{
    
    [Route("/api/customer/")]
    [ApiController]
    [Authorize(Roles="customer")]
    public class CustomerController : ControllerBase
    {
        
        private ICustomerRepository iCustomerRepository;
        private IOrderRepository iOrderRepository;
        private IOrderServiceRepository iOrderServiceRepository;
        private ICustomerService customerService;
        private ICustomerAddressService customerAddressService;
        public CustomerController(ICustomerRepository iCustomerRepository, IOrderRepository iOrderRepository, IOrderServiceRepository iOrderServiceRepository, ICustomerService customerService, ICustomerAddressService customerAddressService)
        {
            this.iCustomerRepository = iCustomerRepository;
            this.iOrderRepository = iOrderRepository;
            this.iOrderServiceRepository = iOrderServiceRepository;
            this.customerService = customerService;
            this.customerAddressService = customerAddressService;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        [Route("getAllCustomer")]
        public IActionResult GetAllCustomerInfomation()
        {
            try
            {
                List<Customer> listCustomer = customerService.getAllCustomer();
                return Ok(listCustomer);

            }
            catch (Exception)
            {
                return BadRequest("Can not get list customer information, try again");
            }
        }

        // GET api/<CustomerController>/5
        [HttpGet]
        [Route("getCustomerDetailById/{id}")]
        public IActionResult GetCustomerById(int id)
        {
            try
            {
                Customer customer = customerService.GetCustomerById(id);
                if (customer == null)
                {
                    return NotFound("Can not find customer, try again. ");
                }

                return Ok(customer);
            }
            catch (Exception)
            {

                return NotFound("Can not find customer, try again. ");
            }
          
           
        }


        //Chức năng: Khách hàng tạo đơn hàng sau khi đã đăng nhập 
        //Với id là id của khách hàng sau khi đăng nhập
        /* [HttpPost("createOrder/customer/{id}")]
         public async Task<IActionResult> CreateOrderTestByCustomer(int id, CustomerFullOrderDto customerFullOrderDto)
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

             *//*CustomerFullOrderDto c = new CustomerFullOrderDto()
             {
                 Address = orderAfterAddtoDb.Address,
                 TotalPrice = orderAfterAddtoDb.TotalPrice,
                 Description = orderAfterAddtoDb.Description,
                 WorkingStatusId = orderAfterAddtoDb.WorkingStatusId,
                 ServiceId = customerFullOrderDto.ServiceId,


             };*//*
             return Ok();
         }*/

        [HttpPost]
        [Route("createOrder/customer/{id}")]
        public async Task<IActionResult> createOrderUsingCustomerId(int id, CustomerCreateOrderTestDto customerCreateOrderTestDto)
        {
            try
            {
                Order order = await customerService.customerCreateOrderUsingCustomerIdTest(id, customerCreateOrderTestDto);
                return Ok(order);
            }
            catch (Exception)
            {
                return BadRequest("Can not create new order please try again. ");

            }
        }

        [HttpGet]
        [Route("getOrderInformation/orderId/{id}")]
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
        [Route("delete/OrderId/{id}")]
        public IActionResult deleteOrderByCustomer(int id)
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

        [HttpGet]
        [Route("getServiceAndCategoryInfor")]
        public IActionResult customerGetServiceAndCategoryInfor()
        {
            try
            {
                List<CustomerServiceDetailCategoryDto> list = customerService.CustomerGetServiceAndCategoryInfor();
                return Ok(list);
            }
            catch (Exception)
            {

                return BadRequest("Can not get information, try again. ");
            }
        }

        [HttpGet]
        [Route("getListCustomerAddressByCustomerId/{id}")]
        public IActionResult customerGetListAddressByCustomerId(int id)
        {
            try
            {
                List<CustomerAddress> listCustomerAddress = customerAddressService.getListAddressByCustomerId(id);
                return Ok(listCustomerAddress);
            }
            catch (Exception)
            {
                return NotFound("Can not get list address of customer, try again. ");
            }
        }

        [HttpGet]
        [Route("getAllAddress/customerId/{id}")]
        public IActionResult customerGetAllAddress(int id)
        {
            try
            {
                List<CustomerAddress> list = customerAddressService.getListAddressByCustomerId(id);
                return Ok(list);
            }
            catch (Exception)
            {

                return BadRequest("Can not get address, please try again. ");
            }
          
        }

        [HttpPut]
        [Route("chooseDefaultAddress/{customerId}/{addressId}")]
        public IActionResult chooseDefaultAddress(int customerId, int addressId)
        {
            List<CustomerAddress> customerAddress = customerAddressService.changeStatusCustomerAddressDefault(customerId,addressId);
            return Ok(customerAddress);
        }

        [HttpPost]
        [Route("addNewAddress")]
        public IActionResult customerAddNewAddress(CustomerCreateNewAddress customerCreateNewAddress)
        {
            try
            {
                CustomerAddress address = customerAddressService.addNewAddressByCustomerId(customerCreateNewAddress);
                return Ok(address);
            }
            catch (Exception)
            {

                return BadRequest("có lỗi trong quá trình thêm địa chỉ mới, vui lòng thử lại ");
            }
        }

        [HttpPut]
        [Route("updateAddress/adressId/{id}")]
        public IActionResult customerUpdateAddress(int id, CustomerAddressDto customerAddressDto)
        {
            /* try
             {
                 CustomerAddress customerAddress = customerAddressService.updateAddressInformation(id, customerAddressDto);
                 return Ok(customerAddress);
             }
             catch (Exception)
             {
                 return BadRequest("Cập nhật địa chỉ không thành công, vui lòng thử lại. ");
             }*/
            CustomerAddress customerAddress = customerAddressService.updateAddressInformation(id, customerAddressDto);
            return Ok(customerAddress);
        }

        [HttpPut]
        [Route("deleteAddress/addressId/{id}")]
        public IActionResult customerDeleteAddress (int id)
        {
            try
            {
                CustomerAddress customerAddress = customerAddressService.customerDeleteAddress(id);
                return Ok(customerAddress);
            }
            catch (Exception)
            {
                return BadRequest("xảy ra lỗi khi xóa địa chỉ, vui lòng thử lại. ");
            }
        }

        [HttpPut]
        [Route("updateOrder/orderId/{id}/customerId/{customerId}")]
        public async Task<IActionResult> customerUpdateOrderByOrderId(int id, int customerId, CustomerUpdateOrderDto dto)
        {
           try
           {
               Order order = await customerService.customerUpdateOrderByOrderIdAsync(id, customerId, dto);
               return Ok(order);
           }
           catch (Exception)
           {
               return BadRequest("Đã có lỗi xảy ra khi cập nhật đơn hàng, vui lòng thử lại");
           }
        }


        [HttpGet]
        [Route("getListOrderByCustomerId/{id}")]
        public IActionResult getListOrderByCustomerId(int id)
        {
            try
            {
                List<CustomerGetListOrderAndOrderServiceDto> list = customerService.customerGetAllOrderByCustomerId(id);
                return Ok(list);
            }
            catch (Exception)
            {

                return BadRequest("Đã xảy ra lỗi khi lấy thông tin, vui lòng thử lại. ");
            }
        }

        [HttpPut]
        [Route("customerChangePassword/accountId/{id}")]
        public IActionResult customerUpdateUsernameAndPassword(int id, CustomerUpdateUsernameAndPasswordDto dto)
        {
            try
            {
                CustomerUpdateUsernameAndPasswordDto customerUpdateUsernameAndPasswordDto = customerService.CustomerUpdateUsernameAndPassword(id,dto);
                if(customerUpdateUsernameAndPasswordDto != null)
                {
                    return Ok(customerUpdateUsernameAndPasswordDto);
                }
                
                    return BadRequest("Mật khẩu không đúng, vui lòng nhập lại. ");         
                
            }
            catch (Exception)
            {
                return BadRequest("Đã có lỗi xảy ra khi cập nhật thông tin, vui lòng thử lại. ");
            }
        }
    }
}
