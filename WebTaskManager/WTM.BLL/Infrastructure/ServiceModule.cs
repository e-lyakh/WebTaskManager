using WTM.DAL.Interfaces;
using WTM.DAL.Repositories;
using Ninject.Modules;


namespace WTM.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>();
        }
    }
}
