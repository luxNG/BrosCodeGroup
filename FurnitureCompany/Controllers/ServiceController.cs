using FurnitureCompany.Data;
using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FurnitureCompany.Controllers
{
    [Route("api/service")]
    [ApiController]
    public class ServiceController : ControllerBase
    {

        private FurnitureCompanyContext furnitureCompanyContext;
        private IServiceRepository iServiceRepository;
        public ServiceController(FurnitureCompanyContext furnitureCompanyContext, IServiceRepository iServiceRepository)
        {
            this.furnitureCompanyContext = furnitureCompanyContext;
            this.iServiceRepository = iServiceRepository;
        }
        // GET: api/<ServiceController>
        [HttpGet]
        [Route("/getAllService")]
        public IActionResult Get()
        {
            return Ok(iServiceRepository.getAllService());
        }

        // GET api/<ServiceController>/5
        [HttpGet("serviceID/{id}")]
        public IActionResult Get(int id)
        {
            Service service = iServiceRepository.GetServiceById(id);
            return Ok(service);
        }

        // POST api/<ServiceController>
        [HttpPost]
        [Route("/AddNewService")]

        public IActionResult Post(ServiceDto serviceDto)
        {
            ServiceDto s = new ServiceDto
            {
                ServiceName = serviceDto.ServiceName,
                ServiceDescription = serviceDto.ServiceDescription,
                Price = serviceDto.Price,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                Status = true,
                Type = 1
            };

            //map
            Service serviceMap = new Service
            {
                ServiceName = s.ServiceName,
                ServiceDescription = s.ServiceDescription,
                Price = s.Price,
                CreateAt = s.CreateAt,
                UpdateAt = s.UpdateAt,
                Status = s.Status,
                Type = s.Type

            };
            int success = iServiceRepository.addService(serviceMap);
            if (success != -1)
            {
                return Ok(serviceMap);
            }
            return BadRequest("cannot add new service");
        }

      

        // DELETE api/<ServiceController>/5
        [HttpDelete("RemoveService/{id}")]
        public IActionResult Delete(int id)
        {
            int isSuccess = iServiceRepository.deleteService(id);
            if (isSuccess != -1)
            {
                return Ok("Delete service success");
            }
            return BadRequest("Delete service fail");
        }

        //UPDATE SERVICE
        [HttpPut("/UpdateService/{id}")]
        public IActionResult updateCategory(int id, ServiceDto s)
        {
            Service findService = iServiceRepository.GetServiceById(id);
            if(findService == null)
            {
                return BadRequest("No information");
            }

            findService.ServiceName = s.ServiceName;
            findService.ServiceDescription = s.ServiceDescription;
            findService.Price = s.Price;
            findService.UpdateAt = DateTime.Now;
            findService.Status = s.Status;
            findService.Type = s.Type;
            iServiceRepository.updateService(findService);
            return Ok("update service success");
        }

      
    }
}
