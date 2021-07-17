using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BudgeteeServer.Extensions
{
    public static class AwsConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddAwsDynamoDb(
             this IServiceCollection services, IConfiguration config)
        {
            var credentials = new BasicAWSCredentials(config["awsAccessKey"], config["awsSecretKey"]);
            var dynamoDbConfig = new AmazonDynamoDBConfig
            {
                RegionEndpoint = RegionEndpoint.APSoutheast2
            };
            var client = new AmazonDynamoDBClient(credentials, dynamoDbConfig);
            services.AddSingleton<IAmazonDynamoDB>(client);
            services.AddSingleton<IDynamoDBContext, DynamoDBContext>();

            return services;
        }
    }
}
