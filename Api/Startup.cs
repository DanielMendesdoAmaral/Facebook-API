using Domain.Handlers.Queries.Comentario;
using Domain.Handlers.Queries.Postagem;
using Domain.Repositories;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            services.AddTransient<IPostagemRepository, PostagemRepository>();
            services.AddTransient<IComentarioRepository, ComentarioRepository>();
            services.AddTransient<ListarQueryHandler, ListarQueryHandler>();
            services.AddTransient<ListarComentariosQueryHandler, ListarComentariosQueryHandler>();
            services.AddTransient<ListarMaisCaracteresQueryHandler, ListarMaisCaracteresQueryHandler>();
            services.AddDbContext<FacebookContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(c => c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
