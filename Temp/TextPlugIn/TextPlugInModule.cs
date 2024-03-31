using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace TextPlugIn;

public class TextPlugInModule : AbpModule {
    public override void OnApplicationInitialization(ApplicationInitializationContext context) {
        var myService = context.ServiceProvider
            .GetRequiredService<MyService>();
        
        myService.Initialize();
    }
}