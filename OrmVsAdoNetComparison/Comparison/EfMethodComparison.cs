using OrmVsAdoNetComparison.Data;
using OrmVsAdoNetComparison.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmVsAdoNetComparison.Comparison
{
    public class EfMethodComparison
    {
        int userId;
        ComparisonContext context;
        public EfMethodComparison()
        {
            context = new ComparisonContext();
            userId = new Random().Next(1000, 100000);
        }

        public void GetUserRandom()
        {
            context.Users.FirstOrDefault(x => x.Id == userId);
        }

        public async Task<User> GetUserRandomTaskRun()
        {
            return await Task.Run(() =>
            {
                return context.Users.FirstOrDefault(x => x.Id == userId);
            });
        }

        public void GetUserRandomProxyCreationFalse()
        {
            context.Configuration.ProxyCreationEnabled = false;
            context.Users.FirstOrDefault(x => x.Id == userId);
        }

        public async void GetUserRandomAsync()
        {
            await context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        }

        public void GetUserRandomAsNoTracking()
        {
            context.Users.AsNoTracking().FirstOrDefault(x => x.Id == userId);
        }

        public void GetUserWhereFirst()
        {
            context.Users.Where(x => x.Id == userId).First();
        }

        public void GetUserWhereTake()
        {
            context.Users.Where(x => x.Id == userId).Take(1);
        }



    }
}
