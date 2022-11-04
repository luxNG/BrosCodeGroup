using FurnitureCompany.Data;
using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.Models;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureCompany.Controllers
{

    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private FurnitureCompanyContext furnitureCompanyContext;
        private IRoleRepository roleRepository;
        public RoleController(FurnitureCompanyContext furnitureCompanyContext, IRoleRepository roleRepository)
        {
            this.furnitureCompanyContext = furnitureCompanyContext;
            this.roleRepository = roleRepository;
        }
        // GET: api/<RoleController>
        [HttpGet]
        [Route("/GetAllRoles")]
        public IActionResult Get()
        {
            return Ok(roleRepository.getAllRole());
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        [HttpPost]
        [Route("/AddNewRole")]
        public IActionResult addRole(RoleDto roleDto)
        {
            RoleDto r = new RoleDto
            {
                roleName = roleDto.roleName,          
            };

            //map
            Role roleMap = new Role
            {
                RoleName = r.roleName,
            };
            int success = roleRepository.addRole(roleMap);
            if(success != -1)
            {
               return Ok(roleMap);
            }
            return BadRequest("cannot add new role");
              
        }


        // DELETE api/<RoleController>/5
        [HttpDelete("removerole/{id}")]
        public IActionResult Delete(int id)
        {
            int isSuccess = roleRepository.deleteRole(id);
            if(isSuccess != -1)
            {
                return Ok("Delete role success");
            }
            return BadRequest("Delete role fail");
        }
    }
}
