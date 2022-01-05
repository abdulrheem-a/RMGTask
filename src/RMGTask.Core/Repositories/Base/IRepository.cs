using RMGTask.Core.Entities.Base;

namespace RMGTask.Core.Repositories.Base
{
    public interface IRepository<T> : IRepositoryBase<T, int> where T : IEntityBase<int>
    {
    }
}
