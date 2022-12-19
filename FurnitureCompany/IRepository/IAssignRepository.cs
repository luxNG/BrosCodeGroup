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
        public void updateAssign(Assign assign);
        public List<Assign> getOrderWorkingStatusByEmployee(int employeeId, int orderWorkingStatusId);

        public Assign getAssignByIdAndEmployeeId(int assignId, int employeeId);
    }
}
