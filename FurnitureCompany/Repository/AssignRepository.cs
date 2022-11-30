using FurnitureCompany.Data;
using FurnitureCompany.DTO;
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
            List<Assign> list = furnitureCompanyContext.Assigns.Where(x => x.EmployeeId == employeeId).Include(x => x.Order).ThenInclude(x=>x.Customer).Include(x=>x.Order).ThenInclude(x=>x.WorkingStatus).ToList();
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
         /*   var customers = db.Customer
                        .Include(c => c.Invoice)
                            .ThenInclude(c => c.InvoiceLine)
                                .ThenInclude(c => c.Track)
                                    .ThenInclude(c => c.MediaType)
                        .Where(c => c.FirstName.StartsWith("A"))
                        .ToList();*/
        }

        public void updateAssign(Assign assign)
        {
            furnitureCompanyContext.Assigns.Update(assign);
            furnitureCompanyContext.SaveChanges();
        }

        public List<Assign> getOrderWorkingStatusByEmployee(int employeeId, int orderWorkingStatusId)
        {
            List<Assign> listAssign = furnitureCompanyContext.Assigns.Where(x=>x.EmployeeId == employeeId).Include(x => x.Order).ThenInclude(x=>x.Customer).Include(x=>x.Order).ThenInclude(x=>x.WorkingStatus).Where(x=>x.Order.WorkingStatusId == orderWorkingStatusId).ToList();
            //List<Assign> list = furnitureCompanyContext.Assigns.Include(x => x.Order).ThenInclude(x => x.w);
            return listAssign;
        }
    }
}
