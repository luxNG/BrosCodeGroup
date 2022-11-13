using FurnitureCompany.Models;

namespace FurnitureCompany.IRepository
{
    public interface IAssignRepository
    {
        public List<Assign> getAllAssign();
      //  public List<Order> getAllOrderByManager();
        public Assign findAssignByManager(int assignId);
        public List<Assign> getAllAssignByEmployeeId(int employeeId);
        public void createAssign(Assign assign);
        public void updateAssignByManager(int id);
    }
}
