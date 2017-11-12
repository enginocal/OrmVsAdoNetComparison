﻿using OrmVsAdoNetComparison.Data;
using OrmVsAdoNetComparison.Data.Entity;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace OrmVsAdoNetComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ComparisonContext())
            {
                SeedUsers(context);
                SeedImages(context);
            }
        }

        private static void SeedUsers(ComparisonContext context)
        {
            for (int i = 1; i < 100000; i++)
            {
                context.Users.AddOrUpdate(user => user.Id, new Data.Entity.User()
                {
                    Id = i,
                    Name = i.ToString() + " . user name",
                    LastName = i.ToString() + " . user lastname"
                });
                context.SaveChanges();
            }
        }

        private static void SeedImages(ComparisonContext context)
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
