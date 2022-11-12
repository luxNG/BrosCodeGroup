using Microsoft.AspNetCore.Mvc;
using ProjectElearning.Data;
using ProjectElearning.DTO;
using ProjectElearning.IRepository;
using ProjectElearning.Models;

namespace ProjectElearning.Controllers
{
    [Route("Role")]
    [ApiController]
    public class RoleApiController : ControllerBase
    {
        private ElearningContext elearningContext;
        private IRoleRepository roleRepository;
        public RoleApiController(ElearningContext elearningContext, IRoleRepository roleRepository)
        {
            this.elearningContext = elearningContext;
            this.roleRepository = roleRepository;
        }

        [HttpGet]
        [Route("/GetAllRoles")]
        public IActionResult Index()
        {
            return Ok(roleRepository.getRole());
        }

        [HttpPost]
        [Route("/AddNewRole")]
        public IActionResult addRole(RoleDTO role)
        {
            RoleDTO r1 = new RoleDTO
            {
                Id = role.Id,
                roleName = role.roleName,
                description = role.description
            };

            //map
            Role roleMap = new Role
            {
                Id = r1.Id,
                RoleName = r1.roleName,
                Description = r1.description
            };
            roleRepository.addNewRole(roleMap);
            return Ok(roleMap);
        }
    }
}
