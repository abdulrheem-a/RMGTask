using RMGTask.Infrastructure.Misc;
using Autofac;

namespace RMGTask.Infrastructure.IoC
{
    public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder builder, ITypeFinder typeFinder);

        int Order { get; }
    }
}
