using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TWT.Repository;

namespace Tiny_Web_Tool
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddOptions();

            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = 146800640;
                x.MultipartBodyLengthLimit = 146800640; // In case of multipart
                x.MemoryBufferThreshold = 146800640;
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;

            });

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(30);
                options.Cookie.HttpOnly = true;
            });

            services.AddDbContext<TWTContext>
                (
                    options =>

                    {
                        options.UseSqlServer(Configuration.GetConnectionString("TWTContext"));

                    },
                    ServiceLifetime.Transient
                );


            //services.AddMvc(config =>
            //{

            //})
            //.AddJsonOptions(options =>
            //{
            //    //options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            //    //options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            //})
            //.AddControllersAsServices()
            //.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);




            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<IUrlHelperFactory, UrlHelperFactory>();



            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                //options.LoginPath = "/Account/Login";_session
                //options.LogoutPath = "/Home/Index";
                //options.Events.OnValidatePrincipal = MVPAuthenticationEvents.ValidatePrincipal;                
            });
            services.Configure<RazorViewEngineOptions>(o =>
            {
                o.AreaViewLocationFormats.Add("/Areas/{2}/{0}" + RazorViewEngine.ViewExtension);
            });
            return BuildDependencyInjectionProvider(services);
        }

        private static IServiceProvider BuildDependencyInjectionProvider(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            // Populate the container using the service collection
            builder.Populate(services);

            // TODO: Add Registry Classes to eliminate reference to Infrastructure
            Assembly webAssembly = Assembly.GetExecutingAssembly();
            //Assembly coreAssembly = Assembly.GetAssembly(typeof(BaseEntity));
            //Assembly infrastructureAssembly = Assembly.GetAssembly(typeof(EfRepository)); // TODO: Move to Infrastucture Registry
            builder.RegisterAssemblyTypes(webAssembly).AsImplementedInterfaces();

            Autofac.IContainer applicationContainer = builder.Build();
            return new AutofacServiceProvider(applicationContainer);
        }

        public void Configure(IApplicationBuilder app, Microsoft.Extensions.Hosting.IHostingEnvironment env)
        {
            //ILoggerFactory loggerFactory
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCookiePolicy();

            //DbInitializer.Seed(app);
            app.UseSession();
            app.UseMvc(routes => {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            //});
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "areas",
            //        template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            //    );
            //    routes.MapRoute(
            //       name: "PagewithDirectory",
            //       template: "services/{Directory}/{PageName}",
            //       defaults: new { controller = "Home", action = "DynamicPage" }
            //    );
            //    routes.MapRoute(
            //       name: "PageWithoutDirectory",
            //       template: "services/{PageName}",
            //       defaults: new { controller = "Home", action = "DynamicPage" }
            //    );

            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
