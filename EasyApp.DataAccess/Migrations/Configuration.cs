namespace EasyApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EasyApp.DataAccess.EasyAppDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EasyApp.DataAccess.EasyAppDBContext context)
        {
            context.Users.AddOrUpdate(f => f.Username,
                new Model.User { Username = "MedZg", FirstName = "Mohamed", LastName = "Zghal", password = "1234", Email = "Zghal.med1@gmail.com" });
        }
    }
}
