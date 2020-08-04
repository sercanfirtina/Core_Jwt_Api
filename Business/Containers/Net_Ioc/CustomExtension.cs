using Business.Concrete;
using Business.Interfaces;
using DataAccess.Concrete.EfCore.Repositories;
using DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Containers.Net_Ioc
{
    public static class CustomExtension
   {
        public static void AddDependenceis(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IProductDal, EfProductRepository>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<IAppRoleDal, EfAppRoleRepository>();
            services.AddScoped<IAppRoleService, AppRoleManager>();

            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddScoped<IAppUserRoleDal, EfAppUserRoleRepository>();
            services.AddScoped<IAppUserRoleService, AppUserRoleManager>();         

        }
    }
}
