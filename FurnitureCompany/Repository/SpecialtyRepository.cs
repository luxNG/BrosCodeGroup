using FurnitureCompany.Data;
using FurnitureCompany.IRepository;
using FurnitureCompany.Models;

namespace FurnitureCompany.Repository
{
    public class SpecialtyRepository : ISpecialtyRepository
    {
        private FurnitureCompanyContext furnitureCompanyContext;
        public SpecialtyRepository(FurnitureCompanyContext furnitureCompanyContext)
        {
            this.furnitureCompanyContext = furnitureCompanyContext;
        }
        public void addSpecialty(Specialty specialty)
        {
            furnitureCompanyContext.Specialties.Add(specialty);
            furnitureCompanyContext.SaveChanges();
        }

        public void deleteSpecialty(int specialtyId)
        {
            Specialty specialty = furnitureCompanyContext.Specialties.FirstOrDefault(x => x.SpecialtyId == specialtyId);
            furnitureCompanyContext.Specialties.Remove(specialty);
            furnitureCompanyContext.SaveChanges();
        }

        public List<Specialty> GetAllSpecialties()
        {
            List<Specialty> specialtieList = furnitureCompanyContext.Specialties.ToList();
            return specialtieList;
        }

        public Specialty GetSpecialtyById(int id)
        {
            Specialty s = furnitureCompanyContext.Specialties.FirstOrDefault(x => x.SpecialtyId == id);
            return s;
        }

        public void updateSpecialty(Specialty specialty)
        {
            furnitureCompanyContext.Specialties.Update(specialty);
            furnitureCompanyContext.SaveChanges();
        }
    }
}
