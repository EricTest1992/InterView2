using InterView.Models.ViewModels;

namespace InterView.Services.Interface
{
    public interface IEmployeeService
    {
        public List<EmployeeViewModel> GetEmployees();

        public EmployeeViewModel GetEmployeesSelect(int employeeID);

        public void InsertEmployees(out string errMsg);
        public void UpdateEmployees(out string errMsg);
        public void DeleteEmployees(out string errMsg);
    }
}
