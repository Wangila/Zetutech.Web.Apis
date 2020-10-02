using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zetutech.Web.Api.ApplicationCore.Interfaces;
using Zetutech.Web.Api.Infrastructure.Data;
using Zetutech.Web.Api.Infrastructure.Logging;
using Zetutech.Web.Api.Interfaces;
using Zetutech.Web.Api.Services;

namespace Zetutech.Web.Api
{
    public class Startup
    {
        private IServiceCollection _services;

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200",
                                        "http://localhost:4000",
                                        "http://www.contoso.com");                                        
                });
            });

            services.AddCors();
            services.AddMvc();

            services.AddDbContext<ZetutechDataDbContext>(c =>
                c.UseSqlServer(Configuration.GetConnectionString("ZetutechDataDBConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

        }

        //// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }

        //    app.Run(async (context) =>
        //    {
        //        await context.Response.WriteAsync("Hello World!");
        //    });
        //}

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();
            


            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
            
        }


    }
}
