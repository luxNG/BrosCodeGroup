using FurnitureCompany.Data;
using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.IService;
using FurnitureCompany.Models;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureCompany.Controllers
{

    [ApiController]
    [Route("/api/role/")]
    public class RoleController : ControllerBase
    {
        private FurnitureCompanyContext furnitureCompanyContext;
        private IRoleService roleService;
        private IRoleRepository roleRepository;
        public RoleController(FurnitureCompanyContext furnitureCompanyContext, IRoleRepository roleRepository,IRoleService roleService)
        {
            this.furnitureCompanyContext = furnitureCompanyContext;
            this.roleRepository = roleRepository;
            this.roleService = roleService;
        }
        // GET: api/<RoleController>
        [HttpGet]
        [Route("GetAllRole")]
        public IActionResult getAllRole()
        {
            try
            {
                List<Role> list = roleService.getAllRole();
                return Ok(list);
                     
            }
            catch (Exception)
            {
                return BadRequest("Can not get list role, try again. ");
            }
        }

        // GET api/<RoleController>/5
        [HttpGet]
        [Route("getRoleById/{id}")]
        public IActionResult getRoleByRoleId(int id)
        {
            try
            {
                RoleGetCustomInforDto roleGetCustomInforDto = roleService.getRoleByRoleId(id);
                return Ok(roleGetCustomInforDto);
            }
            catch (Exception)
            {
                return NotFound("Can not get role information, try again. ");
                
            }
        }


        [HttpPost]
        [Route("addNewRole")]
        public IActionResult addRole(RoleDto roleDto)
        {
            try
            {
                RoleDto roleDtoReturn = roleService.addNewRole(roleDto);
                return Ok(roleDtoReturn);
            }
            catch (Exception)
            {
                return BadRequest("Can not add new role, try again. ");
            }
          
              
        }


        // DELETE api/<RoleController>/5
       /* [HttpDelete("removerole/{id}")]
        public IActionResult Delete(int id)
        {
            int isSuccess = roleRepository.deleteRole(id);
            if(isSuccess != -1)
            {
                return Ok("Delete role success");
            }
            return BadRequest("Delete role fail");
        }*/
    }
}
