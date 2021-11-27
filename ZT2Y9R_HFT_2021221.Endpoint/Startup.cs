using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
