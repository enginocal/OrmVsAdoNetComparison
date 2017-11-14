using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using OrmVsAdoNetComparison.Comparison;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmVsAdoNetComparison
{
    [SimpleJob(launchCount: 3, warmupCount: 1, targetCount: 5)]
    public class EfBenchmark
    {
        EfMethodComparison efComparison;

        public EfBenchmark()
        {
            efComparison = new EfMethodComparison();
        }

        [Benchmark]
        public void GetUserWhereTake() => efComparison.GetUserWhereTake();

        [Benchmark]
        public void GetUserRandomAsNoTracking() => efComparison.GetUserFirstOrDefaultAsNoTracking();

        [Benchmark]
        public void GetUserWhereFirst() => efComparison.GetUserWhereFirst();

        [Benchmark]
        public void GetUserRandom() => efComparison.GetUserFirstOrDefault();

        [Benchmark]
        public async void GetUserRandomTaskRun() => await efComparison.GetUserFirstOrDefaultTaskRun();

        [Benchmark]
        public async Task GetUserRandomAsync() => await efComparison.GetUserFirstOrDefaultAsync();
        
        [Benchmark]
        public void GetUserWhereFirstAsNoTracking() => efComparison.GetUserWhereFirstAsNoTracking();

        
        [Benchmark]
        public void GetUserWhereTakeAsNoTracking() => efComparison.GetUserWhereTakeAsNoTracking();

    }
}
