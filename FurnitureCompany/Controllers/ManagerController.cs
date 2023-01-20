using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.IService;
using FurnitureCompany.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FurnitureCompany.Controllers
{
    [Route("api/manager")]
    [ApiController]
    [Authorize(Roles = "manager")]
    public class ManagerController : ControllerBase
    {
        private IManagerRepository iManagerRepository;
        private ICategoryRepository iCategoryRepository;
        private IAccountService accountService;
        private IManagerService managerService;
        private IWorkingStatusService workingStatusService;
        private IFurnitureServiceService furnitureServiceService;
        private ICustomerService customerService;
        private IEmployeeDayOffRepository employeeDayOffRepository;
        private IEmployeeDayOffService employeeDayOffService;
        public ManagerController(IManagerRepository iManagerRepository, ICategoryRepository iCategoryRepository, IManagerService managerService, IAccountService accountService, IWorkingStatusService workingStatusService, IFurnitureServiceService furnitureServiceService, ICustomerService customerService, IEmployeeDayOffService employeeDayOffService)
        {

            this.iManagerRepository = iManagerRepository;
            this.iCategoryRepository = iCategoryRepository;
            this.managerService = managerService;
            this.accountService = accountService;
            this.workingStatusService = workingStatusService;
            this.furnitureServiceService = furnitureServiceService;
            this.customerService = customerService;
            this.employeeDayOffService = employeeDayOffService;
        }

        // GET: api/<ManagerController>
        [HttpGet]
        [Route("GetAllOrder")]
        public IActionResult getOrderByManager()
        {           
            try
            {
                List<ManagerGetAllOrderDto> list = managerService.getOrderByManager();
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

       /* [HttpGet]
        [Route("ko dùng cái này/getOrderByOrderId/{id}")]
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
        }*/

        [HttpGet]
        [Route("getOrderDetailByOrderId/{id}")]
        public IActionResult managerGetOrderDetailByOrderId(int id)
        {
            try
            {
                ManagerGetOrderDetailDto order = managerService.managerGetOrderDetailByOrderId(id);
                return Ok(order);
            }
            catch (Exception)
            {
                return NotFound("Can not found order information try agian. ");
            }
        }

        [HttpPost]
        [Route("createEmployeeAccount")]
        public IActionResult managerCreateEmployeeAccount(ManagerCreateEmployeeeAccountDto managerCreateEmployeeeAccountDto)
        {
            ManagerCreateEmployeeeAccountDto dto = accountService.managerCreateEmployeeeAccountDto(managerCreateEmployeeeAccountDto);
            return Ok(dto);
        }

        [HttpPost]
        [Route("updateOrderWorkingStatus/orderId/{id}/orderWorkingStatusId/{workingStatusId}")]
        public IActionResult managerUpdateOrderWorkingStatus(int id,int workingStatusId)
        {
            try
            {
                Order order = managerService.updateOrderWorkingStatusByOrderId(id,workingStatusId);
                return Ok(order);
            }
            catch (Exception)
            {
                return BadRequest("Can not update order working status, try again. ");
            }
        }

        [HttpGet]
        [Route("getAllWorkingStatusInfor")]
        public IActionResult managerGetAllWorkingStatusInfor()
        {
            try
            {
                List<WorkingStatus> list = workingStatusService.getAllWorkingStatus();
                return Ok(list);
            }
            catch (Exception)
            {
                return BadRequest("không thể lấy thông tin, vui lòng thử lại");
            }
        }

        [HttpGet]
        [Route("getAllServiceByCategory/categoryId/{id}")]
        public IActionResult managerGetAllServiceByCategoryId(int id)
        {
            try
            {
                List<ManagerGetListServiceDto> list = furnitureServiceService.managerGetServiceByCategoryId(id);
                return Ok(list);
            }
            catch (Exception)
            {
                return BadRequest("không thể lấy thông tin dịch vụ, vui lòng thủ lại");
            }
        }

        [HttpGet]
        [Route("getCustomerInforByCustomerPhone/{phoneNumber}")]
        public IActionResult managerGetCustomerInforByCustomerPhone(string phoneNumber)
        {
            try
            {
                List<Customer> list = managerService.managerGetCustomerOrderInforByCustomerPhoneNumber(phoneNumber);
                return Ok(list);
            }
            catch (Exception)
            {

                return BadRequest("Đã có lỗi xảy ra khi lấy thông tin, vui lòng thử lại. ");
            }
        }

        [HttpGet]
        [Route("getAllEmployeeInformation")]
        public IActionResult managerGetAllEmployeeInformation()
        {
            try
            {
                List<ManagerGetAllEmployeeInforDto> list = managerService.managerGetAllEmployeeInfor();
                return Ok(list);
            }
            catch (Exception)
            {

                return BadRequest("Đã có lỗi xãy ra khi lấy thông tin, vui lòng thử lại. ");
            }
        }
        [HttpGet]
        [Route("getInforDetailByAccountId/id")]
        public IActionResult managerGetInforDetail(int id)
        {
            try
            {
                Manager manager = managerService.getInforDetailByAccountId(id);
                return Ok(manager);
            }
            catch (Exception)
            {

                return BadRequest("Đã xảy ra lỗi, vui lòng thử lại. ");
            }
        }

        [HttpGet]
        [Route("getAllCustomer")]
        public IActionResult managerGetAllCustomerInfomation()
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

        [HttpGet]
        [Route("getEmployeeDayOff")]
        public IActionResult managerGetEmployeeDayOff()
        {
            try
            {
                List<ManagerGetEmployeeDayOffDto> list = employeeDayOffService.managerGetListEmployeeDayOff();
                return Ok(list);                
            }
            catch (Exception)
            {

                return BadRequest("Đã xảy ra lỗi khi truy cập, vui lòng thử lại. ");
            }
        }
        /* [HttpGet]
         [Route("getAllAccountEmployee")]
         public IActionResult managerGetAllAccountInformationOfEmployee()
         {
             try
             {
                 List<Account> list = accountService.managerGetAllAccountInformationOfEmployee();
                 return Ok(list);
             }
             catch (Exception)
             {

                 return BadRequest("Can not get all account information of employee, try again. ");
             }
         }
 */
    }
}
