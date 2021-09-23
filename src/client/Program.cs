using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace graphqlclient
{
    class Program
    {
        static async Task Main(string[] args)
        {
             using var graphQLClient = new GraphQLHttpClient("http://graphqlaci.westeurope.azurecontainer.io/", new NewtonsoftJsonSerializer());

            var ordersAndLines = new GraphQLRequest
            {
                Query = @"query OrdersAndLines ($id: Int!) {
                            order(orderID: $id) {
                            orderID,
                            customerID,
                            orderDate,
                            orderLines {
                                orderLineID,
                                orderID,
                                stockItemID,
                                quantity
                            }			        
                        }
                    }",
                OperationName = "OrdersAndLines",
                Variables = new
                {
                    id = 1
                }
            };

            var graphQLResponse = await graphQLClient.SendQueryAsync<OrdersAndLinesReponse>(ordersAndLines);
            Console.WriteLine("raw response:");
            Console.WriteLine(JsonSerializer.Serialize(graphQLResponse, new JsonSerializerOptions { WriteIndented = true }));

            Console.WriteLine();
            Console.WriteLine($"Order: {graphQLResponse.Data.Order.OrderID} OrderDate: {graphQLResponse.Data.Order.OrderID} ");

            Console.WriteLine();
            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
        }
    }
}
