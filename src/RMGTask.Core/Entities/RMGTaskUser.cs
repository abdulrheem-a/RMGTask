using RMGTask.Core.Entities.Base;
using Microsoft.AspNetCore.Identity;
using System;

namespace RMGTask.Core.Entities
{
    public class RMGTaskUser : IdentityUser<int>, IEntityBase<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime LastLoginTime { get; set; }

        public bool IsWorking { get; set; }
    }
}
