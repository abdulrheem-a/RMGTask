using RMGTask.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RMGTask.Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentModel>> GetDepartmentList();
        Task<DepartmentModel> GetDepartmentById(int departmentId);
        Task<DepartmentModel> CreateDepartment(DepartmentModel department);
        Task UpdateDepartment(DepartmentModel department);
        Task DeleteDepartmentById(int departmentId);
    }
}
