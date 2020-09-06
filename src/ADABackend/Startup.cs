using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using Cardano.Data;
using Microsoft.EntityFrameworkCore;

namespace ADABackend
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // If you need dependency injection with your query object add your query type as a services.
            // services.AddSingleton<Query>();

            // enable InMemory messaging services for subscription support.
            // services.AddInMemorySubscriptions();

            // this enables you to use DataLoader in your resolvers.
            services.AddDataLoaderRegistry();

            // Add GraphQL Services
            services.AddGraphQL(
                SchemaBuilder.New()
                    // enable for authorization support
                    // .AddAuthorizeDirectiveType()
                    .AddQueryType<Query>());
            
            services
            .AddEntityFrameworkNpgsql()
            .AddDbContext<CardanoContext>(
                options => options.UseNpgsql("Host=localhost;Username=postgres;Database=cardano;Password=Test!2#4;Persist Security Info=True"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
                .UseRouting()
                .UseWebSockets()
                .UseGraphQL()
                .UsePlayground()
                .UseVoyager();
        }
    }
}
