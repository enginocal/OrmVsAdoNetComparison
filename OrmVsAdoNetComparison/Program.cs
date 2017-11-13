using BenchmarkDotNet.Running;
using OrmVsAdoNetComparison.Comparison;
using OrmVsAdoNetComparison.Data;
using OrmVsAdoNetComparison.Data.Entity;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace OrmVsAdoNetComparison
{
    class Program
    {
        static  void Main(string[] args)
        {
            try
            {
                //EfMethodComparison compare = new EfMethodComparison();
                //compare.GetUserFirstOrDefault();
                //compare.GetUserFirstOrDefaultAsNoTracking();
                ////await compare.GetUserFirstOrDefaultAsync();
                ////await compare.GetUserFirstOrDefaultTaskRun();
                //compare.GetUserWhereFirst();
                //compare.GetUserWhereFirstAsNoTracking();
                //compare.GetUserWhereTake();
                //compare.GetUserWhereTakeAsNoTracking();
                var summary = BenchmarkRunner.Run(typeof(EfBenchmark));
                //Console.WriteLine();
                //Console.WriteLine(summary);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //throw;
            }

            Console.ReadLine();



            //using (var context = new ComparisonContext())
            //{
            //    //SeedUsers(context);
            //    SeedImages(context);
            //}
        }

        private static void SeedUsers(ComparisonContext context)
        {
            for (int i = 90000; i < 100001; i++)
            {
                context.Users.Add(new Data.Entity.User()
                {
                    Id = i,
                    Name = i.ToString() + " . user name",
                    LastName = i.ToString() + " . user lastname"
                });

                if (i % 10000 == 0)
                {
                    context.SaveChanges();
                }
                //context.SaveChanges();

            }
        }

        private static void SeedImages(ComparisonContext context)
        {
            for (int i = 10000; i < 100001; i++)
            {
                var randomImageCount = new Random().Next(1, 20);
                var user = context.Users.FirstOrDefault(x => x.Id == i);

                for (int j = 1; j < randomImageCount; j++)
                {
                    Image image = new Image
                    {
                        Name = "resimm" + j,
                        Description = "user " + i + " " + j + ". resim",
                        User = user
                    };
                    context.Images.Add(image);
                }

                if (i % 1000 == 0)
                {
                    context.SaveChanges();
                }

                //context.SaveChanges();
            }
        }
    }
}
