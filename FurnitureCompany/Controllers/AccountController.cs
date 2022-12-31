using FurnitureCompany.DTO;
using FurnitureCompany.IService;
using FurnitureCompany.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FurnitureCompany.Controllers
{
    [Route("api/account/")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountService accountService;
        private ICustomerService customerService;
        public AccountController(IAccountService accountService, ICustomerService customerService)
        {
            this.accountService = accountService;
            this.customerService = customerService;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult CustomerRegisterAccount(CustomerCreateAccountDto dto)
        {
            try
            {
                CustomerCreateAccountDto customerCreateAccountDto = customerService.customerCreateAccount(dto);
                if (customerCreateAccountDto == null)
                {
                    return BadRequest("Số điện thoại đã tồn tại, vui lòng dùng số điện thoại khác.");
                    
                }
                return Ok(customerCreateAccountDto);
            }
            catch (Exception)
            {

                return BadRequest("Đã xảy ra lỗi trong quá trình tạo tài khoản, vui lòng thử lại. ");
            }
            
            
        }

        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountController>
        [HttpPost]
        [Route("login")]
        public IActionResult loginIntoServer(LoginDto loginDto)
        {
            try
            {
                UserTokenDto accessAndRefreshToken = accountService.loginIntoServer(loginDto);
                if(accessAndRefreshToken == null)
                {
                    return BadRequest("Số điện thoại đăng nhập hoặc mật khẩu sai, vui lòng nhập lại. ");
                }
                return Ok(accessAndRefreshToken);

            }
            catch (Exception)
            {

                return NotFound("Đã xảy ra lỗi trong quá trình đăng nhập, vui lòng thử lại. ");

            }
            
        }

        // PUT api/<AccountController>/5
        [HttpPut]
        [Route("logout/accountId/{id}")]
        public IActionResult userLogoutAccount(int id)
        {
            Account account =  accountService.userLogoutAccount(id);
            return Ok(account);
        }

       
    }
}
