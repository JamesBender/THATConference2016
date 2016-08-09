using System;
using Common;
using Ninject.Modules;

namespace MyNinjectModules
{
    public class DuplexLoggingModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILoggingSink>().To<DistributedLoggingSync>();
            Bind<EngineWithDuelLoggers>().ToSelf();

            Bind<IDomComponent>().To<OffLineLoggingComponent>();
            
            Bind<IDomComponent>().To<SpecialLoggingComponent>().WhenMemberHas<SpecialLogger>();

        }
    }
}