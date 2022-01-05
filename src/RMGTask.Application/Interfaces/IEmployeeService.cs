using RMGTask.Application.Models;
using RMGTask.Core.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RMGTask.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeModel>> GetEmployeeList();
        Task<IPagedList<EmployeeModel>> SearchEmployee(PageSearchArgs args);
        Task<EmployeeModel> GetEmployeeById(int employeeId);
        Task<IEnumerable<EmployeeModel>> GetEmployeesByName(string name);
        Task<IEnumerable<EmployeeModel>> GetEmployeesByDepartmentId(int departmentId);
        Task<EmployeeModel> CreateEmployee(EmployeeModel employee);
        Task UpdateEmployee(EmployeeModel employee);
        Task DeleteEmployeeById(int employeeId);
    }
}
