using RMGTask.Core.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace RMGTask.Core.Entities
{
    public class RMGTaskRole : IdentityRole<int>, IEntityBase<int>
    {
    }
}
