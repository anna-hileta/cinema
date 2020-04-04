using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cinema.Core.Abstractions;
using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using Cinema.Core.Mapping;
using Cinema.DAL;
using Cinema.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cinema
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CinemaContext>(options => options.UseSqlServer(connectionString));

            services.AddIdentity<Worker, IdentityRole<Guid>>(configuration =>
            {
                configuration.Password.RequiredLength = 6;
                configuration.Password.RequireDigit = false;
                configuration.Password.RequireUppercase = false;
                configuration.Password.RequireLowercase = false;
                configuration.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<CinemaContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(configuration =>
            {
                configuration.Cookie.Name = "Identity.Cookie";
                configuration.LoginPath = "/Account/Login";
            });


            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICheckService, CheckService>();
            services.AddScoped<ICinemaHallService, CinemaHallService>();
            services.AddScoped<ICinemaLocationService, CinemaLocationService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICountryOfOriginService, CountryOfOriginService>();
            services.AddScoped<IDirectorService, DirectorService>();
            services.AddScoped<IFoodAmountService, FoodAmountService>();
            services.AddScoped<IFoodcourtCheckService, FoodcourtCheckService>();
            services.AddScoped<IFoodcourtCheckProductService, FoodcourtCheckProductService>();
            services.AddScoped<IFoodProductsService, FoodProductsService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IMovieGenreService, MovieGenreService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IShowingService, ShowingService>();
            services.AddScoped<ITechnologyService, TechnologyService>();
            services.AddScoped<ITicketCheckService, TicketCheckService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IWorkerService, WorkerService>();

            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(new SelfMapping());
            });

            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton<IMapper>(mapper);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
