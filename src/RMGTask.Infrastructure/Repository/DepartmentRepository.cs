using RMGTask.Core.Entities;
using RMGTask.Core.Paging;
using RMGTask.Core.Repositories;
using RMGTask.Core.Specifications;
using RMGTask.Infrastructure.Data;
using RMGTask.Infrastructure.Paging;
using RMGTask.Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RMGTask.Infrastructure.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(RMGTaskContext context)
            : base(context)
        {
        }

        public  async Task<Department> GetDepartmentByIdAsync(int departmentId)
        {
            var product = await GetByIdAsync(departmentId);
            return product;
        }

        public async Task<IEnumerable<Department>> GetDepartmentListAsync()
        {
            var spec = new DepartmentWithDepartmentSpecification();
            return await GetAsync(spec);
        }

        public async Task<IEnumerable<Department>> GetDepartmentByNameAsync(string departmentName)
        {
            var spec = new DepartmentWithDepartmentSpecification(departmentName);
            return await GetAsync(spec);
        }

    }
}
