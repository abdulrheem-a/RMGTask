using RMGTask.Core.Entities.Base;
using RMGTask.Core.Repositories.Base;
using RMGTask.Infrastructure.Data;

namespace RMGTask.Infrastructure.Repository.Base
{
    public class EnumRepository<T> : RepositoryBase<T, int>, IEnumRepository<T>
        where T : class, IEntityBase<int>
    {
        public EnumRepository(RMGTaskContext context)
            : base(context)
        {
        }
    }
}
