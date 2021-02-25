using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OB.Data;

namespace OB.Voting
{

    public class Startup
    {
        //-----------------------------------------------
        public IConfiguration config { get; }
        //---------------------------------------------------------------------------------------------------
        public Startup(IConfiguration configuration)
        {
            config = configuration;
        }
        //---------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------  SERVICES
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            //--------------------------------
            services.AddAutoMapper(typeof(DomainProfile));
            //--------------------------------
            services.AddTransient<IUow, Uow>();

        }

        //---------------------------------------------------------------------------------------------------
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //--------------------------------
            app.UseRouting();
            //app.UseCors();
            //--------------------------------
            app.UseDefaultFiles();
            app.UseStaticFiles();
            //--------------------------------
            //app.UseAuthentication();
            //app.UseAuthorization();
            //--------------------------------
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

