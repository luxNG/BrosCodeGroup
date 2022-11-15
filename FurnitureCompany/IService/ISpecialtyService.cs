using FurnitureCompany.DTO;
using FurnitureCompany.Models;

namespace FurnitureCompany.IService
{
    public interface ISpecialtyService
    {
        public List<Specialty> GetAllSpecialty();
        public Specialty AddNewSpecialty(SpecialtyDto specialtyDto);
        public Specialty UpdateSpecialty(int id, SpecialtyDto specialtyDto);
        public Specialty DeleteSpecialtyById(int id);


    }
}
