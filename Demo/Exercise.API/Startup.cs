using Exercise.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace Exercise.API
{
    public class Startup
    {
        //how to make configuration variables accessable
        public static IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional:false, reloadOnChange:true);

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //used to add services and dependecy injections. Appllication speceifc service. Services can be injected into another part of the application
            services.AddMvc()
                .AddMvcOptions(o => o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()));
            //Example of how to change the serialization settings
            //.AddJsonOptions(o =>
            //{
            //    switch (o.SerializerSettings.ContractResolver)
            //    {
            //        case null:
            //            return;
            //        case DefaultContractResolver castedResolver:
            //            castedResolver.NamingStrategy = null;
            //            break;
            //    }
            //});
#if DEBUG
            services.AddTransient<IMailService, LocalMailService>();
#else
            services.AddTransient<IMailService, CloudMailService>();
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddProvider(new NLog.Extention.Logging.NLogLoggerProvider());
            loggerFactory.AddNLog();

            //env provides the core abstartyion for working with envrioments. can be injected
            if (env.IsDevelopment())//added developer exceptioon middle ware to pipleline, part of dignostics assembly 
            {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler();
            }

            app.UseStatusCodePages();

            app.UseMvc();

            //app.Run((context) =>
            //{
            //    throw new Exception("Test");
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}