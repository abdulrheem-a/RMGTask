using RMGTask.Core.Entities;
using RMGTask.Core.Specifications.Base;

namespace RMGTask.Core.Specifications
{
    public class EmployeeWithDepartmentSpecification : BaseSpecification<Employee>
    {
        public EmployeeWithDepartmentSpecification(string employeeName)
            : base(p => p.Name.Contains(employeeName))
        {
            AddInclude(p => p.Department);
        }

        public EmployeeWithDepartmentSpecification(int employeeId)
            : base(p => p.Id == employeeId)
        {
            AddInclude(p => p.Department);
        }

        public EmployeeWithDepartmentSpecification()
            : base(null)
        {
            AddInclude(p => p.Department);
        }
    }
}
