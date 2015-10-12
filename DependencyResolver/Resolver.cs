using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web.Security;
using System.Configuration.Provider;
using ORM;
using DAL.Concrete;
using DAL.Interface.Repository;
using BLL.Interface.Services;
using BLL.Services;
using Ninject;
using Ninject.Web.Common;

namespace DependencyResolver
{
    public static class Resolver
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind<DbContext>().To<MovieCatalogueContext>();

            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IMovieService>().To<MovieService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IMarkService>().To<MarkService>();
            kernel.Bind<IFavoriteService>().To<FavoriteService>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<IMovieRepository>().To<MovieRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IMarkRepository>().To<MarkRepository>();
            kernel.Bind<IFavoriteRepository>().To<FavoriteRepository>();
        }
    }
}
