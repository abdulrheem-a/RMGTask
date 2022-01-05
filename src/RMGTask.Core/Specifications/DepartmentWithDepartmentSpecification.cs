using RMGTask.Core.Entities;
using RMGTask.Core.Specifications.Base;

namespace RMGTask.Core.Specifications
{
    public class DepartmentWithDepartmentSpecification : BaseSpecification<Department>
    {
        public DepartmentWithDepartmentSpecification(string departmentName)
            : base(p => p.Name.Contains(departmentName))
        {

        }

        public DepartmentWithDepartmentSpecification()
            : base(null)
        {
        }
    }
}
