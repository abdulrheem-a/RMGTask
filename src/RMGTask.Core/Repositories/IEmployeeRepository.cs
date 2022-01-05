using RMGTask.Core.Entities;
using RMGTask.Core.Paging;
using RMGTask.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RMGTask.Core.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetEmployeeListAsync();
        Task<IPagedList<Employee>> SearchEmployeesAsync(PageSearchArgs args);
        Task<IEnumerable<Employee>> GetEmployeeByNameAsync(string employeeName);
        Task<Employee> GetEmployeeByIdWithDepartmenAsync(int employeeId);
        Task<IEnumerable<Employee>> GetEmployeeByDepartmentAsync(int departmentId);
    }
}
