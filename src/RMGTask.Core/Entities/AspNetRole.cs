using RMGTask.Core.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace RMGTask.Core.Entities
{
    public class AspNetRole : IdentityRole<int>, IEntityBase<int>
    {
    }
}
