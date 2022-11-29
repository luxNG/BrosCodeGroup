using FurnitureCompany.Data;
using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.IService;
using FurnitureCompany.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FurnitureCompany.Controllers
{
    [Route("api/service/")]
    [ApiController]
    public class ServiceController : ControllerBase
    {

      
        private IFurnitureServiceService furnitureServiceService;
        public ServiceController(IFurnitureServiceService furnitureServiceService)
        {
            
            this.furnitureServiceService = furnitureServiceService;
        }

        // GET: api/<ServiceController>
        [HttpGet]
        [Route("getAllService")]
        public IActionResult getAllService()
        {
            try
            {
                List<ServiceGetCustomInforDto> list = furnitureServiceService.getAllService();
                return Ok(list);
            }
            catch (Exception)
            {

                return BadRequest("Can not get service information, try later. ");
            }
           
        }

        // GET api/<ServiceController>/5
        [HttpGet]
        [Route("findServiceById/{id}")]
        public IActionResult getServiceByServiceId(int id)
        {
            try
            {
                ServiceGetCustomInforDto serviceGetCustomInforDto = furnitureServiceService.getServiceInformationByServiceId(id);
                return Ok(serviceGetCustomInforDto);
            }
            catch (Exception)
            {
                return NotFound("Can not found service information, try again. ");
            }
     
        }

        // POST api/<ServiceController>
        [HttpPost]
        [Route("addNewService")]
        public IActionResult managerCreateNewService(ServiceDto serviceDto)
        {
            try
            {
                ServiceDto dto = furnitureServiceService.managerCreateNewService(serviceDto);
                return Ok(dto);
            }
            catch (Exception)
            {
                return BadRequest("Can not add new service, try again. ");
            }
            
        }

      

        // DELETE api/<ServiceController>/5
        [HttpPut]
        [Route("manager/removeServiceById/{id}")]
        public IActionResult managerRemoveServiceById(int id)
        {
            try
            {
                Service service = furnitureServiceService.managerRemoveServiceById(id);
                return Ok(service);
            }
            catch (Exception)
            {

                return BadRequest("Can not remove service, try again. ");
            }
           
        }

        //UPDATE SERVICE
        [HttpPut]
        [Route("manager/updateServiceByServiceId/{id}")]
        public IActionResult managerUpdateServiceInformation(int id, ServiceDto serviceDto)
        {
            try
            {
                Service service = furnitureServiceService.managerUpdateServiceInformation(id, serviceDto);
                return Ok(service);
            }
            catch (Exception)
            {
                return BadRequest("Can not update service information, try again. ");
            }          
           
        }

      
    }
}
