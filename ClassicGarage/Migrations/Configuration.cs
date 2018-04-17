namespace ClassicGarage.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ClassicGarage.DAL;
    using ClassicGarage.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<GarageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ClassicGarage.DAL.GarageContext";
        }

        protected override void Seed(GarageContext context)
        {
            SeedOwner(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        private void SeedOwner(GarageContext context)
        {
            for (int i=0; i<10; i++)
            {
                var owners = new OwnerModels
                {
                    FirstName = "Imiê" + i.ToString(),
                    LastName = "Nazwisko" + i.ToString(),
                    PhoneNum = "123456789" + i,
                    Mail = "mail" + i.ToString() + "@poczta.pl"
                };
                context.Owner.Add(owners);
            }
            context.SaveChanges();
        }
    }
}
