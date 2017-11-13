using log4net;
using OrmVsAdoNetComparison.Data;
using OrmVsAdoNetComparison.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmVsAdoNetComparison.Comparison
{
    public class EfMethodComparison
    {
        int userId;
        ComparisonContext context;
        protected readonly ILog logger;

        public EfMethodComparison()
        {
            context = new ComparisonContext();
            logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            context.Database.Log = (dbLog => Debug.Write(dbLog));
            userId = new Random().Next(1000, 100000);
        }

        public void GetUserFirstOrDefault()
        {
            context.Users.FirstOrDefault(x => x.Id == userId);
        }

        public async Task<User> GetUserFirstOrDefaultTaskRun()
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

        public async Task GetUserFirstOrDefaultAsync()
        {
            await context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        }

        public void GetUserFirstOrDefaultAsNoTracking()
        {
            context.Users.AsNoTracking().FirstOrDefault(x => x.Id == userId);
        }

        public void GetUserWhereFirstAsNoTracking()
        {
            context.Users.AsNoTracking().Where(x => x.Id == userId).First();
        }

        public void GetUserWhereFirst()
        {
            context.Users.Where(x => x.Id == userId).First();
        }

        public void GetUserWhereTakeAsNoTracking()
        {
            context.Users.AsNoTracking().Where(x => x.Id == userId).Take(1);
        }

        public void GetUserWhereTake()
        {
            context.Users.Where(x => x.Id == userId).Take(1);
        }



    }
}
