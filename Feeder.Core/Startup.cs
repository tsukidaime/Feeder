using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Feeder.Data;
using Feeder.Data.EventStore;
using Feeder.Infrastructure.Behaviours;
using Feeder.Infrastructure.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace Feeder
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddMediatR(typeof(Startup).Assembly);
            services.AddSwagger();
            services.AddAutoMapper(typeof(DomainProfile).Assembly);
            services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")
                ));

            services.AddSingleton<IEventStoreDbContext, EventStoreDbContext>();

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(EventLoggerBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehavior<,>));
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseErrorHandling();
            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Feeder");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
