using RMGTask.Core.Entities.Base;

namespace RMGTask.Core.Repositories.Base
{
    public interface IEnumRepository<T> : IRepositoryBase<T, int> where T : IEntityBase<int>
    {
    }
}
