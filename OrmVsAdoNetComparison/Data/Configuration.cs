using MySql.Data.Entity;
using OrmVsAdoNetComparison.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmVsAdoNetComparison.Data
{
    internal sealed class Configuration : DbMigrationsConfiguration<ComparisonContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            const string providerName = "MySql.Data.MySqlClient";

            SetSqlGenerator(providerName, new MySqlMigrationSqlGenerator());
            SetHistoryContextFactory(providerName, (conn, schema) => new MySqlHistoryContext(conn, schema));
            CodeGenerator = new ComparisonCodeGenerator();
        }

        protected override void Seed(ComparisonContext context)
        {
            //SeedUsers(context);
            //SeedImages(context);
            base.Seed(context);
        }

        private void SeedUsers(ComparisonContext context)
        {
            for (int i = 1; i < 100000; i++)
            {
                context.Users.AddOrUpdate(user => user.Id, new Entity.User()
                {
                    Id = i,
                    Name = i.ToString() + " . user name",
                    LastName = i.ToString() + " . user lastname"
                });
                context.SaveChanges();
            }
        }

        private void SeedImages(ComparisonContext context)
        {
            for (int i = 1; i < 100000; i++)
            {
                var randomImageCount = new Random().Next(1, 100);
                var user = context.Users.FirstOrDefault(x => x.Id == i);

                for (int j = 1; j < randomImageCount; i++)
                {
                    Image image = new Image
                    {
                        Name = "resimm" + j,
                        Description = "user " + i + " " + j + ". resim",
                        User = user
                    };
                    context.Images.Add(image);
                }

                context.SaveChanges();
            }
        }
    }
}
