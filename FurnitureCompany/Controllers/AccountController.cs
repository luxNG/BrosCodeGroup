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
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
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
            UserTokenDto accessAndRefreshToken = accountService.loginIntoServer(loginDto);
            return Ok(accessAndRefreshToken);
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
