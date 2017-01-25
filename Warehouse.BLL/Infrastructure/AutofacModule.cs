using Autofac;
using Warehouse.DAL.EF;
using Warehouse.DAL.EF.Repositories;
using Warehouse.DAL.Interfaces;
using Warehouse.DAL.Interfaces.Repositories;

namespace Warehouse.BLL.Infrastructure
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerRequest();
            builder.RegisterType<ShopRepository>().As<IShopRepository>().InstancePerRequest();
            builder.RegisterType<ProductInTheShopRepository>().As<IProductInTheShopRepository>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
        }
    }
}
