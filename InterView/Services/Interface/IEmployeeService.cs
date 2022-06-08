using InterView.Models.DAO;
using InterView.Models.ViewModels;

namespace InterView.Services.Interface
{
    public interface IEmployeeService
    {
        public List<EmployeeViewModel> GetEmployees();

        public EmployeeViewModel GetEmployeesSelect(int employeeID);

        public void InsertEmployees(Employee employee);

        public void UpdateEmployees(int employeeID);

        public void DeleteEmployees(int employeeID);
    }
}
