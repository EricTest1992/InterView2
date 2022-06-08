using InterView.Models.DAO;
using InterView.Models.ViewModels;
using InterView.Services.Interface;
using System.Transactions;

namespace InterView.Services
{
    public class EmployeeService : IEmployeeService
    {
        private InterViewContext _interViewContext;

        public EmployeeService(InterViewContext interViewContext)
        {
            _interViewContext = interViewContext;
        }

        public void DeleteEmployees(int employeeID)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeViewModel> GetEmployees()
        {
            List<Employee> employees = _interViewContext.Employees.ToList();

            return employees.Select(x => new EmployeeViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Phone = x.Phone
            }).ToList();
        }

        public EmployeeViewModel GetEmployeesSelect(int employeeID)
        {
            throw new NotImplementedException();
        }

        public void InsertEmployees(Employee employee)
        {
            using TransactionScope transaction = new();

            _interViewContext.Employees.Add(employee);

            _interViewContext.SaveChanges();

            transaction.Complete();
        }

        public void UpdateEmployees(int employeeID)
        {
            throw new NotImplementedException();
        }
    }
}
