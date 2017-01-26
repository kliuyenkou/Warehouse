using Autofac;
using Warehouse.BLL.Interfaces;
using Warehouse.BLL.Services;

namespace Warehouse.Web.Infrastructure
{
    public class AutofacWebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ShopService>().As<IShopService>().InstancePerRequest();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerRequest();
        }
    }
}