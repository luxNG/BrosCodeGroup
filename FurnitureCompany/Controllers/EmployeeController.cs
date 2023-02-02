using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.IService;
using FurnitureCompany.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FurnitureCompany.Controllers
{
    [Route("employee")]
    [ApiController]
    [Authorize(Roles = "employee")]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository iEmployeeRepository;
        private IEmployeeService iEmployeeService;
        private IEmployeeDayOffService employeeDayOffService;
        private ICustomerService customerService;
       
        public EmployeeController(IEmployeeRepository iEmployeeRepository, IEmployeeService iEmployeeService, IEmployeeDayOffService employeeDayOffService, ICustomerService customerService)
        {
            this.iEmployeeRepository = iEmployeeRepository;
            this.iEmployeeService = iEmployeeService;
            this.employeeDayOffService = employeeDayOffService;
            this.customerService = customerService;
        }

        // Lấy danh sách tất cả employee có trong database thực hiện bởi manager
        [HttpGet]
        [Route("/getAllEmployee")]
        public IActionResult GetAllEmployeeInformation()
        {
            try
            {
                List<Employee> list = iEmployeeService.GetAllEmployeeInformation();
                return Ok(list);
            }
            catch (Exception)
            {

                return NotFound();
            }
           
        }

        // Xem thông tin chi tiết của thợ 
        // id: là id của thợ sau khi thực hiện đăng nhập vào app mobile
        [HttpGet("/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                Employee employee = iEmployeeService.GetEmployeeById(id);
                // return StatusCode(StatusCodes.Status200OK, employee);
                return Ok(employee);
            }
            catch (Exception)
            {
                return NotFound();
            }
           
            
        }

        // Thêm mới 1 thợ vào trong database được thực hiện bởi Manager
        [HttpPost]
        [Route("addNewEmployeeByManager")]
        public IActionResult addNewEmployeeByManger(EmployeeDto employeeDto)
        {
            try
            {
                Employee employee = iEmployeeService.addNewEmployeeByManger(employeeDto);
                return Ok(employee);
            }
            catch (Exception)
            {
                return BadRequest("Cannot create new employee. Try agian");
            }
           
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("employeeUpdateAvatar/{id}")]
        public IActionResult UpdateEmployeeAvatar(int id, string newAvatarUrl)
        {
            Employee e = iEmployeeRepository.getEmployeeById(id);
            e.ImageUrl = newAvatarUrl;
            iEmployeeRepository.updateEmployeeUrlImage(e);
           
            return Ok(e + " Update image success");
        }

        [HttpPut("emplooyeeUpdateInformation/{id}")]
        public IActionResult UpdateEmployeeInformation(int id, EmployeeDto employeeDto)
        {
            Employee e = iEmployeeRepository.getEmployeeById(id);
            e.Email = employeeDto.Email;
            iEmployeeRepository.updateEmployeeUrlImage(e);
            return Ok(e + " Update Email Success");
        }

        [HttpPut("updateEmployeeStatus/{id}")]
        public IActionResult UpdateEmployeeStatus(int id, bool workStatus)
        {
            Employee e = iEmployeeRepository.getEmployeeById(id);
            e.WorkingStatus = workStatus;
            iEmployeeRepository.updateEmployeeUrlImage(e);
            return Ok(e + " Update working status success ");
        }

        // Lấy chi tiết danh sách đc manager assign cho Employee xem
        // employeeId: là Id của thợ 
        [HttpGet]
        [Route("ViewAssign/employeeId/{id}")]
        public IActionResult viewAssignByEmployee(int id)
        {
            try
            {
                List<EmployeeAssignOrderDto> listDto = iEmployeeService.viewAssignByEmployee(id);
                return Ok(listDto);
            }
            catch (Exception)
            {

                return NotFound();
            }
           
        }

        // Lấy chi tiết thông tin đơn hàng bởi employee thông qua mobile
        // orderId: Là mã đơn hàng 
        [HttpGet]
        [Route("getorderdetailbyemployee/order/{orderId}")]
        public IActionResult getOrderDetailByEmployee(int orderId)
        {
            try
            {
                EmployeeGetOrderDetailDto employeeGetOrderDetailDto = iEmployeeService.getOrderDetailByEmployee(orderId);
                return Ok(employeeGetOrderDetailDto);
            }
            catch (Exception)
            {

                return NotFound();
            }
           
        }

        [HttpPut]
        [Route("/report_order_assigned/{id}")]
        public async Task<IActionResult> employeeReportOrderAssignByOrderId(int id, EmployeeReportFormDto employeeReportFormDto)
        {
            try
            {
                Order order = await iEmployeeService.employeeReportOrderAssignByOrderId(id, employeeReportFormDto);
                return Ok(order);
            }
            catch (Exception e)
            {
                return BadRequest(e);

         
            }
        }

        [HttpGet]
        [Route("viewOrderStatus/employeeId/{id}/orderWorkingStatus/{orderWorkingStatusId}")]
        public IActionResult viewOrderStatusIsWorking(int id, int orderWorkingStatusId)
        {
            try
            {
                List<EmployeeAssignOrderDto> list = iEmployeeService.employeeGetOrderWorkingStatus(id, orderWorkingStatusId);
                return Ok(list);
            }
            catch (Exception)
            {

                return NotFound("Can not found information, try again. ");
            }
          
        }

        [HttpGet]
        [Route("getAllDayOffbyEmployeeId/employeeId/{id}")]
        public IActionResult getAllDayOffByEmployeeId(int id)
        {
            try
            {
                List<EmployeeDayOff> list = employeeDayOffService.getAllDayOffByEmployeeId(id);
                return Ok(list);
            }
            catch (Exception)
            {

                return BadRequest("không thể tải thông tin, vui lòng thử lại");
            }
        }

        // POST api/<EmployeeDayOffController>
        [HttpPost]
        [Route("employeeCreateFormForAbsent")]
        public IActionResult employeeCreateAbsentForm(EmployeeDayOffDto employeeDayOffDto)
        {
            try
            {
                EmployeeDayOff employeeDayOff = employeeDayOffService.employeeCreateAbsentForm(employeeDayOffDto);
                return Ok(employeeDayOff);
            }
            catch (Exception)
            {
                return BadRequest("Đã có lỗi xảy ra khi tạo form, vui lòng thử lại. ");
            }

        }

        // PUT api/<EmployeeDayOffController>/5
        [HttpPut]
        [Route("updateDayOffInformation/dayOffId/{id}")]
        public IActionResult employeeUpdateDayOffInformation(int id, EmployeeUpdateDayOffDto dto)
        {
            try
            {
                EmployeeDayOff employeeDayOff = employeeDayOffService.employeeUpdateDayOffDayOffId(id, dto);
                return Ok(employeeDayOff);
            }
            catch (Exception)
            {
                return BadRequest("Có lỗi xảy ra trong quá trình cập nhật, vui lòng thử lại.");
            }
        }

        [HttpPut]
        [Route("employeeCancelAbsentFormByFormId/{id}")]
        public IActionResult employeeCancelAbsentFormByFormId(int id)
        {
            try
            {
                EmployeeDayOff employeeDayOff = employeeDayOffService.cancelAbsentFormByFormId(id);
                return Ok(employeeDayOff);
            }
            catch (Exception)
            {
                return BadRequest("Đã có lỗi xảy ra khi hủy đơn, vui lòng thử lại. ");
            }
        }


        [HttpDelete]
        [Route("deleteServiceInOrder/{orderId}/orderServiceId/{orderServiceId}")]
        public IActionResult customerDeleteServiceInOrder(int orderId, int orderServiceId)
        {
            try
            {
                bool isDeletedSuccess = customerService.deleteOrderService(orderId, orderServiceId);
                if (isDeletedSuccess)
                {
                    return Ok("Đã xóa dịch vụ thành công. ");
                }
                else
                {
                    return BadRequest("Đã xảy ra lỗi khi xóa dịch vụ, vui lòng thử lại. ");
                }

            }
            catch (Exception)
            {

                return BadRequest("Đã xảy ra lỗi khi cập nhật đơn hàng, vui lòng thử lại. ");
            }
        }




    }
}
