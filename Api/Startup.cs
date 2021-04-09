using Domain.Handlers.Queries.Comentario;
using Domain.Handlers.Queries.Postagem;
using Domain.Repositories;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer("Default", options => //Autenticação padrão -> Caso o usuário entre com email e senha.
                 {
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuer = true,
                         ValidIssuer = "Facebook",
                         ValidateAudience = true,
                         ValidAudience = "Facebook",
                         ValidateLifetime = true,
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Facebook-b71e507ae8f44b4396530166279942af"))
                     };
                 })
                .AddJwtBearer("Google", options => //Autenticação do Google -> Caso o usuário entre com o google
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "Carongo",
                        ValidateAudience = true,
                        ValidAudience = "Carongo",
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Carongo-b71e507ae8f44b4396530166279942af"))
                    };
                });
                //Pode ter uma com o github também, mas acho q o site tem que estar hospedado.


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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
