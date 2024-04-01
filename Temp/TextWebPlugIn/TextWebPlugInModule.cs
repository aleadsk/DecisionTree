using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.Modularity;

namespace TextWebPlugIn;

[DependsOn(typeof(AbpAspNetCoreMvcUiThemeSharedModule))]
public class TextWebPlugInModule : AbpModule {
    public override void PreConfigureServices(ServiceConfigurationContext context) {
        PreConfigure<IMvcBuilder>(mvcBuilder => {
            //Add plugin assembly
            mvcBuilder.PartManager.ApplicationParts.Add(new AssemblyPart(typeof(TextWebPlugInModule).Assembly));

            //Add CompiledRazorAssemblyPart if the PlugIn module contains razor views.
            mvcBuilder.PartManager.ApplicationParts.Add(new CompiledRazorAssemblyPart(typeof(TextWebPlugInModule).Assembly));
        });
    }
}