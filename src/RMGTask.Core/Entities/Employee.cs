using RMGTask.Core.Entities.Base;

namespace RMGTask.Core.Entities
{
    public class Employee : Entity
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
