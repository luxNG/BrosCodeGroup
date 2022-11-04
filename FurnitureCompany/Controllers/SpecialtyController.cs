using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FurnitureCompany.Controllers
{
    [Route("api/specialty")]
    [ApiController]
    public class SpecialtyController : ControllerBase
    {

        private ISpecialtyRepository specialtyRepository;
        public SpecialtyController(ISpecialtyRepository specialtyRepository)
        {
            this.specialtyRepository = specialtyRepository;
        }
        // GET: api/<SpecialtyController>
        [HttpGet]
        [Route("getAllSpecialty")]
        public IActionResult GetAllSpecialty()
        {
            List<Specialty> listSpecialty = specialtyRepository.GetAllSpecialties();
            return Ok(listSpecialty);
        }


        // POST api/<SpecialtyController>
        [HttpPost]
        [Route("addNewSpecialty")]
        public IActionResult AddNewSpecialty(SpecialtyDto specialtyDto)
        {
            Specialty s = new Specialty();
            s.SpecialtyName = specialtyDto.SpecialtyName;
            specialtyRepository.addSpecialty(s);
            return Ok(s);
        }



        // PUT api/<SpecialtyController>/5
        [HttpPut("{id}")]
        public void UpdateSpecialty(int id, string specialtyName)
        {
            Specialty s =  specialtyRepository.GetSpecialtyById(id);
            if( s != null)
            {
                s.SpecialtyName = specialtyName;
                specialtyRepository.updateSpecialty(s);
            }
        }



        // DELETE api/<SpecialtyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            specialtyRepository.deleteSpecialty(id);   
        }
    }
}
