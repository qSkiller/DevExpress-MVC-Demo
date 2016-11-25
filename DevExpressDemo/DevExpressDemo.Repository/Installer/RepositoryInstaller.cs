using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DevExpressDemo.Data;
using DevExpressDemo.IRepository;
using DevExpressDemo.Repository.UnitOfWork;

namespace DevExpressDemo.Repository.Installer
{
    public class RepositoryInstaller :IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IUnitOfWorkFactory>().ImplementedBy<UnitOfWorkFactory>().LifestylePerWebRequest(),
                Component.For<IUnitOfWork>().ImplementedBy<EntityFrameworkUnitOfWork>().LifestylePerWebRequest(),
                Component.For<IDbFactory>().ImplementedBy<DataBaseFactory>().LifestyleSingleton(),
                Component.For<DevExpressDemoContext>().LifestylePerWebRequest(),
                Component.For<IUserRepository>().ImplementedBy<UserRepository>().LifestyleSingleton(),
                Component.For<IEmployeeRepository>().ImplementedBy<EmployeeRepository>().LifestyleSingleton(),
                Component.For<IShapeRepository>().ImplementedBy<ShapeRepository>().LifestyleSingleton()
                );
        }
    }
}