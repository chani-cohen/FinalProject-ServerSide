using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Classes;
using BL.Interfaces;
using BL.Classes;
using DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace EF_Demo_Contacts
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //בשביל חיבור צד הקליינט והסרבר ואיפשור גישה מאותה כתובת גם לקיינט וגם לסרבר
            //בדרך כלל מנסה לחסום כזה דבר כי זה יכול להיות גניבת מידע
            //לכן להגדיר לו שזה אני המפתחת ולכן זה תקין
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    builder.SetIsOriginAllowed(_ => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options=>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddControllers();

            //בשביל מנגנון הזרקת התלויות
            services.AddScoped(typeof(ISiteDAL), typeof(SiteDAL));
            services.AddScoped(typeof(ISiteBL), typeof(SiteBL));

            services.AddScoped(typeof(INeighborhoodDAL), typeof(NeighborhoodDAL));
            services.AddScoped(typeof(INeighborhoodBL), typeof(NeighborhoodBL));

            services.AddScoped(typeof(IUserDAL), typeof(UserDAL));
            services.AddScoped(typeof(IUserBL), typeof(UserBL));

            services.AddScoped(typeof(IDriverDAL), typeof(DriverDAL));
            services.AddScoped(typeof(IDriverBL), typeof(DriverBL));

            services.AddScoped(typeof(ITicketDAL), typeof(TicketDAL));
            services.AddScoped(typeof(ITicketBL), typeof(TicketBL));

            services.AddScoped(typeof(ITravelDAL), typeof(TravelDAL));
            services.AddScoped(typeof(ITravelBL), typeof(TravelBL));

            services.AddScoped(typeof(ICustomerDAL), typeof(CustomerDAL));
            services.AddScoped(typeof(ICustomerBL), typeof(CustomerBL));

            services.AddScoped(typeof(IOrderDAL), typeof(OrderDAL));
            services.AddScoped(typeof(IOrderBL), typeof(OrderBL));

            services.AddScoped(typeof(IStreetDAL), typeof(StreetDAL));
            services.AddScoped(typeof(IStreetBL), typeof(StreetBL));

            services.AddScoped(typeof(IStationDAL), typeof(StationDAL));
            services.AddScoped(typeof(IStationBL), typeof(StationBL));

            services.AddScoped(typeof(IBusDAL), typeof(BusDAL));
            services.AddScoped(typeof(IBusBL), typeof(BusBL));

            services.AddDbContext<TravelsContext>(options =>
            options.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=Travels;Integrated Security=True"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {          
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            //בשביל חיבור צד הקליינט והסרבר ואיפשור גישה מאותה כתובת גם לקיינט וגם לסרבר
            //בדרך כלל מנסה לחסום כזה דבר כי זה יכול להיות גניבת מידע
            //לכן להגדיר לו שזה אני המפתחת ולכן זה תקין
            app.UseCors();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
