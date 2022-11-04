using FurnitureCompany.Data;
using FurnitureCompany.IRepository;
using FurnitureCompany.Models;
using Microsoft.EntityFrameworkCore;

namespace FurnitureCompany.Repository
{
    public class AssignRepository:IAssignRepository
    {
       
        private FurnitureCompanyContext furnitureCompanyContext;
        public AssignRepository(FurnitureCompanyContext furnitureCompanyContext)
        {
            this.furnitureCompanyContext = furnitureCompanyContext;
        }

        public void createAssign(Assign assign)
        {
            furnitureCompanyContext.Assigns.Add(assign);
            furnitureCompanyContext.SaveChanges();
        }

        public Assign findAssignByManager(int assignId)
        {
            Assign assign = furnitureCompanyContext.Assigns.Where(x => x.AssignId == assignId).FirstOrDefault();
            return assign;
        }

        public List<Assign> getAllAssignByEmployeeId(int employeeId)
        {
            List<Assign> list = furnitureCompanyContext.Assigns.Where(x => x.EmployeeId == employeeId).ToList();
            return list;
        }

        public List<Assign> getAllAssign()
        {
            List<Assign> list = furnitureCompanyContext.Assigns.ToList();
            return list;
        }

        public void updateAssignByManager(int id)
        {
            throw new NotImplementedException();
        }
    }
}
