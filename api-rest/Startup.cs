using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using api_rest.Persistence.Contexts;
using api_rest.Domains.Repositories;
using api_rest.Domains.Services;
using api_rest.Services;
using api_rest.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;


namespace api_rest
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
           services.AddControllers();

            services.AddDbContext<AppDbContext>(options => {
                options.UseInMemoryDatabase("supermarket-api-in-memory");
            });

            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<ICategoryService,CategoryService>();
            //services.AddAutoMapper();
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            
             

        }

        public void Configure(IApplicationBuilder app,IHostingEnvironment env){
            if(env.IsDevelopment()){
                app.UseDeveloperExceptionPage();
            }else{
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseMvc();

        }

       
        
    }
}
