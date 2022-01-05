using RMGTask.Core.Entities.Base;
using RMGTask.Core.Repositories.Base;
using RMGTask.Infrastructure.Data;

namespace RMGTask.Infrastructure.Repository.Base
{
    public class Repository<T> : RepositoryBase<T, int>, IRepository<T>
        where T : class, IEntityBase<int>
    {
        public Repository(RMGTaskContext context)
            : base(context)
        {
        }
    }
}
