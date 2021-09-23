using System.Threading.Tasks;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace grapql_serverless
{
    public partial class graphql_serverless_func
    {

        private readonly GraphQLAzureFunctionsExecutorProxyV12 _graphQlExecutorProxy;
        public graphql_serverless_func(GraphQLAzureFunctionsExecutorProxyV12 graphQlExecutorProxy)
        {
            _graphQlExecutorProxy = graphQlExecutorProxy;
        }        
   
        //[Function("graphql_serverless_func")]
        [Function(nameof(GraphQL))]
        public async Task<HttpResponseData> GraphQL(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "graphql")] HttpRequestData req)
            => await _graphQlExecutorProxy.ExecuteQueryAsync(req).ConfigureAwait(false);
    }
}
