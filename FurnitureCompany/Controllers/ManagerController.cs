﻿using FurnitureCompany.DTO;
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
        private IAccountService accountService;
        private IManagerService managerService;
        public ManagerController(IManagerRepository iManagerRepository, ICategoryRepository iCategoryRepository, IManagerService managerService, IAccountService accountService)
        {

            this.iManagerRepository = iManagerRepository;
            this.iCategoryRepository = iCategoryRepository;
            this.managerService = managerService;
            this.accountService = accountService;
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
