using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IHotelService, HotelManager>(); // Birisi senin constructor'�nda IHotelService ihtiya� duyuyorsa sen ona HotelManager �ret demi� olduk.
            services.AddSingleton<IHotelRepository, HotelRepository>();
            services.AddSwaggerDocument(config => {
                config.PostProcess = (doc => {
                    doc.Info.Title= "Hotels Api";
                    doc.Info.Version = "1.0.15";
                    doc.Info.Contact = new NSwag.OpenApiContact()
                    {
                        Name = "Sefa Uzuno�lu",
                        Url = "https://github.com/sefauzunoglu",
                        Email = "sefauzunogluu@gmail.com" 
                    };
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
