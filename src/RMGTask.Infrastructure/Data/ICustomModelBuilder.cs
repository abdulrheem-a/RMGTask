using Microsoft.EntityFrameworkCore;

namespace RMGTask.Infrastructure.Data
{
    public interface ICustomModelBuilder
    {
        void Build(ModelBuilder modelBuilder);
    }
}
