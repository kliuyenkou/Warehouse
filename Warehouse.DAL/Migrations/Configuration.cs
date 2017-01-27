using Warehouse.DAL.Entities;
using System.Data.Entity.Migrations;

namespace Warehouse.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Warehouse.DAL.EF.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Warehouse.DAL.EF.ApplicationDbContext context)
        {


        }
    }
}
