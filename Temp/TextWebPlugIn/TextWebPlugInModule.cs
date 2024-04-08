using Microsoft.AspNetCore.Mvc.ApplicationParts;
using TextWebPlugIn.Data;
using TextWebPlugIn.Infrastructure;
using TextWebPlugIn.Interfaces.Repository;
using TextWebPlugIn.Interfaces.Service;
using TextWebPlugIn.Service;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace TextWebPlugIn;

[DependsOn(typeof(AbpAspNetCoreMvcUiThemeSharedModule))]
[DependsOn(typeof(AbpAspNetCoreMvcUiBootstrapModule))]
    public class TextWebPlugInModule : AbpModule {
    public override void PreConfigureServices(ServiceConfigurationContext context) {
        PreConfigure<IMvcBuilder>(mvcBuilder => {
            //Add plugin assembly
            mvcBuilder.PartManager.ApplicationParts.Add(new AssemblyPart(typeof(TextWebPlugInModule).Assembly));

            //Add CompiledRazorAssemblyPart if the PlugIn module contains razor views.
            mvcBuilder.PartManager.ApplicationParts.Add(new CompiledRazorAssemblyPart(typeof(TextWebPlugInModule).Assembly));
        });

        context.Services.AddMongoDbContext<TextWebPlugInDbContext>(options => {
            options.AddDefaultRepositories();
            options.AddDefaultRepositories(includeAllEntities: true);
        });
        context.Services.AddScoped<ICmsAppService, CmsAppService>();
        context.Services.AddScoped<ICmsRepository, CmsRepository>();
    }
}