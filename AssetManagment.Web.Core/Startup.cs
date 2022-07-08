using Furion;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AssetManagment.Web.Core;

public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.AddDateFormatString("yyyy-MM-dd");
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
        }).AddInjectBase();
        services.AddSpecificationDocuments();
        services.AddDynamicApiControllers();
        SqlsugarSetup.AddSqlsugarSetup(services, App.Configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseInjectBase();

        app.UseSpecificationDocuments();


        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            
        });
    }
}
