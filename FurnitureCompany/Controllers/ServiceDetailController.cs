using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FurnitureCompany.Controllers
{
    [Route("api/servicedetail")]
    [ApiController]
    public class ServiceDetailController : ControllerBase
    {
        private  IServiceDetailRepository iServiceDetailRepository;
        public ServiceDetailController(IServiceDetailRepository iServiceDetailRepository)
        {

            this.iServiceDetailRepository = iServiceDetailRepository;
        }
        // GET: api/<ServiceDetailController>
        [HttpGet]
        [Route("/getAllServiceDetail")]
        public IActionResult GetAllServiceDetail()
        {
            List<ServiceDetail> list = iServiceDetailRepository.getAllServiceDetail();
            return Ok(list);
        }

        // GET api/<ServiceDetailController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ServiceDetail serviceDetail = iServiceDetailRepository.GetServiceDetailById(id);
            return Ok(serviceDetail);
        }

        // POST api/<ServiceDetailController>
        [HttpPost]
        public void Post(ServiceDetailDto serviceDetailDto)
        {
            ServiceDetail serviceDetail = new ServiceDetail()
            {
                ServiceId = serviceDetailDto.ServiceId,
                ServiceDetailName = serviceDetailDto.ServiceDetailName,
                Description = serviceDetailDto.Description,
                Price = serviceDetailDto.Price,
                Type = serviceDetailDto.Type,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                Status = true,
            };
            iServiceDetailRepository.addNewServiceDetail(serviceDetail);

        }

        // PUT api/<ServiceDetailController>/5
        [HttpPut("updateServiceDetail/{id}")]
        public void updateServiceDetail(int id, ServiceDetailDto serviceDetailDto)
        {
            ServiceDetail serviceDetail = iServiceDetailRepository.GetServiceDetailById(id);
            serviceDetail.ServiceDetailName = serviceDetailDto.ServiceDetailName;
            serviceDetail.Price = serviceDetailDto.Price;
            serviceDetail.Description = serviceDetailDto.Description;
            serviceDetail.UpdateAt = DateTime.Now;
            iServiceDetailRepository.updateServiceDetail(serviceDetail);
        }

        // PUT api/<ServiceDetailController>/5
        [HttpPut("updateServiceDetailStatus/{id}")]
        public void updateServiceDetailStatus(int id)
        {
            ServiceDetail serviceDetail = iServiceDetailRepository.GetServiceDetailById(id);
            serviceDetail.Status = false;
            iServiceDetailRepository.updateServiceDetailStatus(serviceDetail);
        }
    }
}
