using FurnitureCompany.Models;

namespace FurnitureCompany.IRepository
{
    public interface ISpecialtyRepository
    {
        public List<Specialty> GetAllSpecialties();
        public Specialty GetSpecialtyById(int id);
        public void addSpecialty(Specialty specialty);
        public void updateSpecialty(Specialty specialty);
        public void deleteSpecialty(int specialtyId);
    }
}
