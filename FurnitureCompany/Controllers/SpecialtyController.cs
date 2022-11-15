using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.IService;
using FurnitureCompany.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FurnitureCompany.Controllers
{
    [Route("api/specialty/")]
    [ApiController]
    public class SpecialtyController : ControllerBase
    {

        private ISpecialtyRepository specialtyRepository;
        private ISpecialtyService specialtyService;
        public SpecialtyController(ISpecialtyRepository specialtyRepository, ISpecialtyService specialtyService)
        {
            this.specialtyRepository = specialtyRepository;
            this.specialtyService = specialtyService;
        }

        // Lấy tất cả danh sách chứa thông tin chuyên môn của thợ
        [HttpGet]
        [Route("getAllSpecialty")]
        public IActionResult GetAllSpecialty()
        {
            try
            {
                List<Specialty> listSpecialty = specialtyService.GetAllSpecialty();
                return Ok(listSpecialty);
            }
            catch (Exception)
            {
                return NotFound();
            }
           
        }


        // POST Manager tạo 1 chuyên môn mới và thêm vào database
        [HttpPost]
        [Route("addNewSpecialty")]
        public IActionResult AddNewSpecialty(SpecialtyDto specialtyDto)
        {
            try
            {
                Specialty specialty = specialtyService.AddNewSpecialty(specialtyDto);
                return Ok(specialty);
            }
            catch (Exception)
            {

                return BadRequest("Cannot create new specialty, try again. ");
            }
            
        }



        // PUT api/<SpecialtyController>/5
        [HttpPut("updatespecialtyname/{id}")]
        public IActionResult UpdateSpecialty(int id, SpecialtyDto specialtyDto)
        {
            try
            {
                Specialty specialty = specialtyService.UpdateSpecialty(id, specialtyDto);
                return Ok(specialty);
            }
            catch (Exception)
            {
                return BadRequest("Cannot update specialty name, Try again. ");
                
            }
        }



        // DELETE specialty bằng cách cập nhật status trong databse specialty từ true thành false
        [HttpPut("deletespecialtystatus/specialtyId/{id}")]
        public IActionResult DeleteSpecialtyById (int id)
        {
            try
            {
                Specialty specialty = specialtyService.DeleteSpecialtyById(id);
                return Ok(specialty);
            }
            catch (Exception)
            {
                return BadRequest("Cannot delete specialty, Try again. ");               
            }
            
        }
    }
}
