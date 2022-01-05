using RMGTask.Core.Entities;
using RMGTask.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RMGTask.Core.Repositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<IEnumerable<Department>> GetDepartmentListAsync();
        Task<IEnumerable<Department>> GetDepartmentByNameAsync(string departmentName);
        Task<Department> GetDepartmentByIdAsync(int departmentId);
    }
}
