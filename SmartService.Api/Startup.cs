using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SmartService.DataAccess.DatabaseContext;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using SmartService.DataAccess.Repository;
using SmartService.Domain.Abstractions;
using SmartService.DataAccess.Repositories;

namespace SmartService.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();


            services.AddScoped(typeof(IUserListCategoryRepository), typeof(UserListCategoryRepository));
            services.AddScoped(typeof(ITaskUserCacheRepository), typeof(TaskUserCacheRepository));
            services.AddScoped(typeof(ITaskUserCacheAggregateResponsibilityRepository), typeof(TaskUserCacheAggregateResponsibilityRepository));
            

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmartService.TestTask", Version = "1.0" });
            });

            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options =>
                options.UseNpgsql(connectionString));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
