using RMGTask.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace RMGTask.Infrastructure.Data
{
    class RMGTaskCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>()
             .HasOne(psa => psa.Department);
            modelBuilder.Entity<Employee>().Property(p => p.Salary).HasColumnType("decimal(10,2)").HasConversion<decimal>();


        }
    }
}
