namespace Mailler.DataAccess.Migrations
{
    using Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Mailler.DataAccess.ContactOrganizerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Mailler.DataAccess.ContactOrganizerDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Contacts.AddOrUpdate(f => f.Name,

                    new Contact() { Name = "Çaðlar 1", Surname = "Dursun 1", EMail = "test1@testmail.com"},
                    new Contact() { Name = "Çaðlar 2", Surname = "Dursun 2", EMail = "test2@testmail.com" },
                    new Contact() { Name = "Çaðlar 3", Surname = "Dursun 3", EMail = "test3@testmail.com" },
                    new Contact() { Name = "Çaðlar 4", Surname = "Dursun 4", EMail = "test4@testmail.com" }
            );
        }
    }
}
