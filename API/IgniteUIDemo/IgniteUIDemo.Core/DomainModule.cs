using IgniteUIDemo.Core.Persistence;
using Ninject.Modules;

namespace IgniteUIDemo.Core
{
    public class DomainModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<Repository>().InSingletonScope();
            Bind<IToDoService>().To<ToDoService>();
        }
    }
}
