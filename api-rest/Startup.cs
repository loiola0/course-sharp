using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using api_rest.Domains.Repositories;
using api_rest.Domains.Services;
using api_rest.Services;
using api_rest.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.Extensions.Hosting;
using api_rest.Persistence.Contexts;

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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            
            // services.AddDbContext<AppDbContext>(options => {
            //     options.UseInMemoryDatabase("supermarket-api-in-memory");
            // });

            services.AddDbContext<AppDbContext>(p=>p.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            
             services.AddScoped<ICategoryRepository,CategoryRepository>();
             services.AddScoped<ICategoryService,CategoryService>();
             //
             services.AddScoped<IProductRepository,ProductRepository>();
             services.AddScoped<IProductService,ProductService>();
             
             services.AddAutoMapper(typeof(Startup));


             
             services.AddScoped<IUnitOfWork,UnitOfWork>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env){
        if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });
        }

       
        
    }
}
