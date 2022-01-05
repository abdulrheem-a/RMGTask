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
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RMGTaskContext context)
            : base(context)
        {
        }

        public override async Task<Employee> GetByIdAsync(int id)
        {
            var employees = await GetAsync(p => p.Id == id, null, new List<Expression<Func<Employee, object>>> { p => p.Department });
            return employees.FirstOrDefault();
        }

        public async Task<IEnumerable<Employee>> GetEmployeeListAsync()
        {
            var spec = new EmployeeWithDepartmentSpecification();
            return await GetAsync(spec);
        }

        public Task<IPagedList<Employee>> SearchEmployeesAsync(PageSearchArgs args)
        {
            var query = Table.Include(p => p.Department);

            var orderByList = new List<Tuple<SortingOption, Expression<Func<Employee, object>>>>();

            if (args.SortingOptions != null)
            {
                foreach (var sortingOption in args.SortingOptions)
                {
                    switch (sortingOption.Field)
                    {
                        case "id":
                            orderByList.Add(new Tuple<SortingOption, Expression<Func<Employee, object>>>(sortingOption, p => p.Id));
                            break;
                        case "name":
                            orderByList.Add(new Tuple<SortingOption, Expression<Func<Employee, object>>>(sortingOption, p => p.Name));
                            break;
                        case "department.name":
                            orderByList.Add(new Tuple<SortingOption, Expression<Func<Employee, object>>>(sortingOption, p => p.Department.Name));
                            break;
                    }
                }
            }

            if (orderByList.Count == 0)
            {
                orderByList.Add(new Tuple<SortingOption, Expression<Func<Employee, object>>>(new SortingOption { Direction = SortingOption.SortingDirection.ASC }, p => p.Id));
            }

            //TODO: FilteringOption.Operator will be handled
            var filterList = new List<Tuple<FilteringOption, Expression<Func<Employee, bool>>>>();

            if (args.FilteringOptions != null)
            {
                foreach (var filteringOption in args.FilteringOptions)
                {
                    switch (filteringOption.Field)
                    {
                        case "id":
                            filterList.Add(new Tuple<FilteringOption, Expression<Func<Employee, bool>>>(filteringOption, p => p.Id == (int)filteringOption.Value));
                            break;
                        case "name":
                            filterList.Add(new Tuple<FilteringOption, Expression<Func<Employee, bool>>>(filteringOption, p => p.Name.Contains((string)filteringOption.Value)));
                            break;
                        case "department.name":
                            filterList.Add(new Tuple<FilteringOption, Expression<Func<Employee, bool>>>(filteringOption, p => p.Department.Name.Contains((string)filteringOption.Value)));
                            break;
                    }
                }
            }

            var employeePagedList = new PagedList<Employee>(query, new PagingArgs { PageIndex = args.PageIndex, PageSize = args.PageSize, PagingStrategy = args.PagingStrategy }, orderByList, filterList);

            return Task.FromResult<IPagedList<Employee>>(employeePagedList);
        }

        public async Task<IEnumerable<Employee>> GetEmployeeByNameAsync(string employeeName)
        {
            var spec = new EmployeeWithDepartmentSpecification(employeeName);
            return await GetAsync(spec);
        }

        public async Task<Employee> GetEmployeeByIdWithDepartmenAsync(int employeeId)
        {
            var spec = new EmployeeWithDepartmentSpecification(employeeId);
            return (await GetAsync(spec)).FirstOrDefault();
        }

        public async Task<IEnumerable<Employee>> GetEmployeeByDepartmentAsync(int departmentId)

        {
            return await Table
                .Where(x => x.DepartmentId == departmentId)
                .ToListAsync();
        }
    }
}
