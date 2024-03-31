using DecisionTreeTest.Localization;
using Volo.Abp.AspNetCore.Components;

namespace DecisionTreeTest;

public abstract class DecisionTreeTestComponentBase : AbpComponentBase
{
    protected DecisionTreeTestComponentBase()
    {
        LocalizationResource = typeof(DecisionTreeTestResource);
    }
}
