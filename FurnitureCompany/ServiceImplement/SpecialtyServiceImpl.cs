using FurnitureCompany.DTO;
using FurnitureCompany.IRepository;
using FurnitureCompany.IService;
using FurnitureCompany.Models;

namespace FurnitureCompany.ServiceImplement
{
    public class SpecialtyServiceImpl:ISpecialtyService
    {
        private ISpecialtyRepository specialtyRepository;
        public SpecialtyServiceImpl(ISpecialtyRepository specialtyRepository)
        {
            this.specialtyRepository = specialtyRepository;
        }

        public Specialty AddNewSpecialty(SpecialtyDto specialtyDto)
        {
            Specialty specialty = new Specialty();
            specialty.SpecialtyName = specialtyDto.SpecialtyName;
            specialty.Status = true;
            specialtyRepository.addSpecialty(specialty);
            return specialty;
        }

        public Specialty DeleteSpecialtyById(int id)
        {
            Specialty specialty = specialtyRepository.GetSpecialtyById(id);
            if(specialty != null)
            {
                specialty.Status = false;
                specialtyRepository.deleteSpecialty(specialty);
            }
            return specialty;
        }

        public List<Specialty> GetAllSpecialty()
        {
            List<Specialty> listSpecialty = specialtyRepository.GetAllSpecialties();
            return listSpecialty;
        }

        public Specialty UpdateSpecialty(int id, SpecialtyDto specialtyDto)
        {
            Specialty specialty = specialtyRepository.GetSpecialtyById(id);
            if (specialty != null)
            {
                specialty.SpecialtyName = specialtyDto.SpecialtyName;
                specialtyRepository.updateSpecialty(specialty);
            }
            return specialty;
        }
    }
}
