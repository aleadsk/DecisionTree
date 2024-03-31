using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace DecisionTreeTest;

[Dependency(ReplaceServices = true)]
public class DecisionTreeTestBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "DecisionTreeTest";
}
