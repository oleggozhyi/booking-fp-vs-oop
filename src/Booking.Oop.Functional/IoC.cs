using System.Reflection;
using Autofac;

namespace Booking.Oop.Functional
{
    public class IoC
    {
        public static readonly IContainer Container = RegisterDependecies();

        private static IContainer RegisterDependecies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
               .AsImplementedInterfaces();
            return builder.Build();
        }
    }
}
