using RMGTask.Application.Interfaces;
using RMGTask.Application.Services;
using RMGTask.Infrastructure.IoC;
using RMGTask.Infrastructure.Misc;
using Autofac;

namespace RMGTask.Application.IoC
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {

            // services
            builder.RegisterType<EmployeeService>().As<IEmployeeService>().InstancePerLifetimeScope();
            builder.RegisterType<DepartmentService>().As<IDepartmentService>().InstancePerLifetimeScope();
        }

        public int Order => 2;
    }
}
