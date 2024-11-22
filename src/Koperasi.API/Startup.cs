using MediatR;
using Koperasi.API.Handlers;
using Koperasi.API.Mapping;
using Koperasi.API.Queries;
using Koperasi.Application.Extensions;
using Koperasi.Application.Mapping;
using Koperasi.Infrastructure.Extensions;
using Koperasi.Infrastructure.Persistence;
using System.Reflection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Builder;

namespace Koperasi.API
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
            services.AddCors(options => options.AddPolicy("Cors", builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            //services.AddDbContext<ProductStoreDataContext>(options => 
            //    options.UseNpgsql(Configuration.GetConnectionString("ProductStoreConnectionString"))
            //);
            services.AddDbContext<DataContext>();
            services.AddMvc(options => { options.EnableEndpointRouting = false; });
            services.AddControllers();
            services.AddAutoMapper(GetMapperProfileAssemblies());

            services.AddInfrastructureServices();
            services.AddApplicationServices();
            services.AddSwaggerGen();
            services.AddMediatR(typeof(LoginUserQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(RegisterUserCommandHandler).GetTypeInfo().Assembly);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseMvc();
            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static IEnumerable<Assembly> GetMapperProfileAssemblies()
        {
            yield return typeof(APILevelMapping).GetTypeInfo().Assembly;
            yield return typeof(ApplicationLevelMapping).GetTypeInfo().Assembly;
        }
    }
}
