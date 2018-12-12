using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using CashmereServer.Database;
using CashmereServer.GraphQL.Repositories;
using CashmereServer.GraphQL.DataLoaders;
using CashmereServer.GraphQL.Schemas;
using CashmereServer.GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SpaServices.Webpack;

namespace CashmereServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            HostingEnvironment = environment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("CashmereDbContext");
            services.AddEntityFrameworkNpgsql().AddDbContext<CashmereDbContext>(
               options => options.UseNpgsql(connectionString));

            // If you need dependency injection with your query object add your query type as a services.
            // services.AddSingleton<Query>();
            // Add the custom services like repositories etc ...
            services.AddTransient<CashmereRepository>();
            services.AddTransient<Query>();
            services.AddTransient<Mutation>();

            // Add GraphQL Services
            services.AddGraphQL(sp => Schema.Create(c =>
            {
                c.RegisterServiceProvider(sp);

                c.RegisterDataLoader<AccountDataLoader>();

                c.RegisterQueryType<Query>();
                c.RegisterMutationType<MutationType>();

                c.RegisterType<UserType>();
                c.RegisterType<AccountType>();
                c.RegisterType<GroupType>();
                c.RegisterType<TeamType>();
            }));

            services.AddSpaStaticFiles();
            services.AddRouting();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // for vue
                // app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                // {
                //     HotModuleReplacement = true
                // });
            }

            app.UseGraphQL();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseMvc();
            // app.UseMvc(routes =>
            // {
            //     routes.MapRoute(
            //         name: "default",
            //         template: "{controller=Home}/{action=Index}/{id?}");
            //     ///////////////////////////////////////////////////
            //     routes.MapSpaFallbackRoute(
            //         name: "spa-fallback",
            //         defaults: new { controller = "Home", action = "Index" });
            //     ///////////////////////////////////////////////////////
            // });
        }
    }
}
