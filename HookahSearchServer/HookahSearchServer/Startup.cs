using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using HookahSearchServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.StaticFiles;

namespace HookahSearchServer
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
            string con = "Data Source=АДМИН-ПК;Initial Catalog=HookahSearch;Integrated Security=False;User ID=sa;Password=Ahfyrtyintqy101;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            services.AddDbContext<DbTables>(options => options.UseSqlServer(con));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //publisher validation
                        ValidateIssuer = true,
                        //publisher presentation string
                        ValidIssuer = AuthOptions.ISSUER,

                        //validation of token consumer
                        ValidateAudience = true,
                        //installation of token consumer
                        ValidAudience = AuthOptions.AUDIENCE,
                        //validation of token life time
                        ValidateLifetime = true,

                        //installation of the token security key
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        //validation of the token security key
                        ValidateIssuerSigningKey = true,


                    };
                });

            services.AddMvc();

            services.AddSingleton<IHookahRepository, HookahRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseHsts();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=user}");
            });

            //app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
