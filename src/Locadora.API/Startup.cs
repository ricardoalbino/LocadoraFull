using Locadora.API.Shared;
using Locadora.Domain.Interfaces;
using Locadora.Domain.Notificacoes;
using Locadora.Domain.Services;
using Locadora.Infra.Context;
using Locadora.Infra.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Locadora.API
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

            //Conecao  Banco
            services.AddDbContext<DataContext>(options =>
            options.UseSqlite(
                Configuration.GetConnectionString("DefaultConnection")));

            //Injeção  de Dependencia
            services.AddScoped<DataContext>();


            //Repositorios
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IFilmeRepository, FilmeRepository>();

            //Servicos
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IFilmeService, FilmeService>();

            //Notificadores
            services.AddScoped<INotificador, Notificador>();

            //Swagger
            //services.AddSwaggerGen(swagger =>
            //{
            //    swagger.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "LocadoraAPI" });
            //});



            //Cors
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.WithOrigins("https://localhost:44353"));
            });


            //TOKEN  JWT
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.ChaveCriptografia);

            services.AddAuthentication(x => 
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme    = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => 
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken            = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey    = true,
                    IssuerSigningKey            = new SymmetricSecurityKey(key),
                    ValidateIssuer              = true,
                    ValidateAudience            = true,
                    ValidAudience               = appSettings.ValidoEm,
                    ValidIssuer                 = appSettings.Emissor

                };
            });




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(options => options.AllowAnyOrigin());


            //app.UseSwagger();
            //app.UseSwaggerUI(c => { c.SwaggerEndpoint("v1/swagger.json", "API name"); });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(options => options.WithOrigins("https://localhost:44353"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });



        }
    }
}