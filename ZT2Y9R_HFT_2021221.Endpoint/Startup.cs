using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZT2Y9R_HFT_2021221.Data;
using ZT2Y9R_HFT_2021221.Endpoint.Services;
using ZT2Y9R_HFT_2021221.Logic;
using ZT2Y9R_HFT_2021221.Repository;

namespace ZT2Y9R_HFT_2021221.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IPlayersLogic, PlayersLogic>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<ICoachesLogic, CoachesLogic>();
            services.AddTransient<ICoachRepository, CoachRepository>();
            services.AddTransient<IClubsLogic, ClubsLogic>();
            services.AddTransient<IClubRepository, ClubRepository>();
            services.AddTransient<IBusinessManagerLogic, BusinessManagerLogic>();
            services.AddTransient<IBusinessManagerRepository, BusinessManagerRepository>();
            services.AddTransient<SuperLeagueDbContext, SuperLeagueDbContext>();

            services.AddSignalR();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = " ZT2Y9R_HFT_2021221.Endpoint", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", " ZT2Y9R_HFT_2021221.Endpoint v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { Msg = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));

            app.UseCors(x => x
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:25918"));


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
