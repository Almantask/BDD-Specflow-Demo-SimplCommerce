using System;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.WebEncoders;
using Microsoft.OpenApi.Models;
using SimplCommerce.Host.Extensions;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Modules;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Core.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Localization.Extensions;
using SimplCommerce.Module.Localization.TagHelpers;

namespace SimplCommerce.Host
{
    public class Startup
    {
        public Startup(ConfigurationManager configuration)
        {
            Configuration = configuration;
        }

        public ConfigurationManager Configuration { get; }

        public void ConfigureServices(IServiceCollection services, IWebHostEnvironment env)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            Configuration.AddEntityFrameworkConfig(options =>
                options.UseSqlServer(connectionString));

            GlobalConfiguration.WebRootPath = env.WebRootPath;//builder.Environment.WebRootPath;
            GlobalConfiguration.ContentRootPath = env.ContentRootPath;//builder.Environment.ContentRootPath;

            services.AddModules();
            services.AddCustomizedDataStore(Configuration);
            services.AddCustomizedIdentity(Configuration);
            services.AddHttpClient();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IRepositoryWithTypedId<,>), typeof(RepositoryWithTypedId<,>));
            services.AddScoped<SlugRouteValueTransformer>();

            services.AddCustomizedLocalization();

            services.AddCustomizedMvc(GlobalConfiguration.Modules);
            services.Configure<RazorViewEngineOptions>(
                options => { options.ViewLocationExpanders.Add(new ThemeableViewLocationExpander()); });
            services.Configure<WebEncoderOptions>(options =>
            {
                options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All);
            });
            services.AddScoped<ITagHelperComponent, LanguageDirectionTagHelperComponent>();
            services.AddTransient<IRazorViewRenderer, RazorViewRenderer>();
            services.AddAntiforgery(options => options.HeaderName = "X-XSRF-Token");
            services.AddCloudscribePagination();

            foreach (var module in GlobalConfiguration.Modules)
            {
                var moduleInitializerType = module.Assembly.GetTypes()
                   .FirstOrDefault(t => typeof(IModuleInitializer).IsAssignableFrom(t));
                if ((moduleInitializerType != null) && (moduleInitializerType != typeof(IModuleInitializer)))
                {
                    var moduleInitializer = (IModuleInitializer)Activator.CreateInstance(moduleInitializerType);
                    services.AddSingleton(typeof(IModuleInitializer), moduleInitializer);
                    moduleInitializer.ConfigureServices(services);
                }
            }

            services.AddScoped<ServiceFactory>(p => p.GetService);
            services.AddScoped<IMediator, Mediator>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SimplCommerce API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseWhen(
                    context => !context.Request.Path.StartsWithSegments("/api", StringComparison.OrdinalIgnoreCase),
                    a => a.UseExceptionHandler("/Home/Error")
                );
                app.UseHsts();
            }

            app.UseWhen(
                context => !context.Request.Path.StartsWithSegments("/api", StringComparison.OrdinalIgnoreCase),
                a => a.UseStatusCodePagesWithReExecute("/Home/ErrorWithCode/{0}")
            );

            app.UseHttpsRedirection();
            app.UseCustomizedStaticFiles(env);
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SimplCommerce API V1");
            });
            app.UseCookiePolicy();
            app.UseCustomizedIdentity();
            app.UseCustomizedRequestLocalization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDynamicControllerRoute<SlugRouteValueTransformer>("/{**slug}");
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            var moduleInitializers = app.ApplicationServices.GetServices<IModuleInitializer>();
            foreach (var moduleInitializer in moduleInitializers)
            {
                moduleInitializer.Configure(app, env);
            }
        }
    }
}
