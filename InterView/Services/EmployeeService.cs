using InterView.Models.DAO;
using InterView.Models.ViewModels;
using InterView.Services.Interface;
using System.Transactions;

namespace InterView.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly InterViewContext _interViewContext;

        public EmployeeService(InterViewContext interViewContext)
        {
            _interViewContext = interViewContext;
        }

        public void DeleteEmployee(int employeeID)
        {
            using TransactionScope transaction = new();

            Employee employee = _interViewContext.Employees.First(employee => employee.Id == employeeID);

            _interViewContext.Employees.Remove(employee);

            _interViewContext.SaveChanges();

            transaction.Complete();
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
            Employee employee = _interViewContext.Employees.First(employee => employee.Id == employeeID);

            return new EmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Address = employee.Address,
                Phone = employee.Phone
            };
        }

        public void InsertEmployees(Employee employee)
        {
            using TransactionScope transaction = new();

            _interViewContext.Employees.Add(employee);

            _interViewContext.SaveChanges();

            transaction.Complete();
        }

        public void UpdateEmployees(Employee tempEmployee)
        {
            using TransactionScope transaction = new();

            Employee employee = _interViewContext.Employees.First(employee => employee.Id == tempEmployee.Id);

            employee.Name = tempEmployee.Name;
            employee.Address = tempEmployee.Address;
            employee.Phone = tempEmployee.Phone;

            _interViewContext.SaveChanges();

            transaction.Complete();
        }
    }
}
