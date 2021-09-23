using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace grapql_serverless
{
    public class Program
    {
        public async static Task Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(s =>
                {
                    s.AddPooledDbContextFactory<wwiCtx>(ob => {ob.UseSqlServer(System.Environment.GetEnvironmentVariable("CONNSTR"));});
                    s.AddSingleton<GraphQLAzureFunctionsExecutorProxyV12>();
                    s.AddGraphQLServer()
                    .AddQueryType<Query>()
                    .AddFiltering()
                    .AddSorting();

                }).Build();

            await host.RunAsync();
        }
    }
}