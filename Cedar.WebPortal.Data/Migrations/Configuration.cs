namespace Cedar.WebPortal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Cedar.WebPortal.Domain.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<CedarContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CedarContext context)
        {
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
            //TODO: move it outside
            if (!context.Set<News>().Any())
            {
                context.Set<News>()
                    .AddOrUpdate(
                        new News
                        {
                            Contents = "This is Sample Contents 1",
                            CreatedAt = DateTime.Now.AddDays(1),
                            ExpirationDate = DateTime.Now.AddDays(101),
                            Code = 1,
                            Title = "Sample Title 1"
                        });
                context.Set<News>()
                    .Add(
                        new News
                        {
                            Contents = "This is Sample Contents 2",
                            CreatedAt = DateTime.Now,
                            ExpirationDate = DateTime.Now.AddDays(100),
                            Code = 2,
                            Title = "Sample Title 2"
                        });
            }
        }
    }
}
