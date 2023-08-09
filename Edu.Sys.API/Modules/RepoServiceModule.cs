using Module = Autofac.Module;
using System.Reflection;
using EeduSys.Repository;
using EduSys.Service.Mapping;
using Autofac;
using EeduSys.Repository.UnitOfWork;
using EduSys.Core.UnitOfWork;
using EeduSys.Repository.Repositories;
using EduSys.Core.Repositories;
using Autofac.Core;
using EduSys.Core.Services;
using EduSys.Service.Services;
using Edu.Sys.Caching;

namespace Edu.Sys.API.Modules
{
    public class RepoServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            var assembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(assembly, repoAssembly, serAssembly)
                .Where(o => o.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(assembly, repoAssembly, serAssembly)
                .Where(o => o.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductServiceWithCaching>().As<IProductService>();

            builder.RegisterGeneric(typeof(GenericRepository<>))
                .As(typeof(IGenericRepository<>))
                .AsImplementedInterfaces();

            builder.RegisterGeneric(typeof(Service<>))
                .As(typeof(IService<>))
                .AsImplementedInterfaces();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        }
    }
}
