using BudgeteeServer.DataAccess.DAO;
using BudgeteeServer.Extensions;
using BudgeteeServer.GraphQL;
using BudgeteeServer.GraphQL.Types;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BudgeteeServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private const string corsPolicyName = "AllowAnyPolicy";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy(corsPolicyName, builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddConfig(Configuration);
            services.AddAwsDynamoDb(Configuration);
            services.AddControllers();
            services.AddScoped<IBudgetSummaryRepository, BudgetSummaryRepository>();
            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<BudgetSummaryType>()
                .AddMutationType<Mutation>()
                .AddFiltering()
                .AddSorting();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(corsPolicyName);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
                endpoints.MapControllers();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Welcome to the Budgetee API");
                });
            });

            app.UseGraphQLVoyager(new VoyagerOptions()
            {
                GraphQLEndPoint = "/graphql"
            }, "/graphql-voyager");
        }
    }
}
