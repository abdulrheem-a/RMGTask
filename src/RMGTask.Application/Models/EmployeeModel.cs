using RMGTask.Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMGTask.Application.Models
{
    public class EmployeeModel: BaseModel
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public DepartmentModel Department { get; set; }
        public int DepartmentId { get; set; }

    }
}
