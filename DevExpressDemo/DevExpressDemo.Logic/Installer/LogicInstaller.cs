using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DevExpressDemo.ILogic;

namespace DevExpressDemo.Logic.Installer
{
    public class LogicInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IUserLogic>().ImplementedBy<UserLogic>().LifestylePerWebRequest(),
                Component.For<IEmployeeLogic>().ImplementedBy<EmployeeLogic>().LifestylePerWebRequest(),
                Component.For<IShapeLogic>().ImplementedBy<ShapeLogic>().LifestylePerWebRequest()
                );
        }
    }
}