using DecisionTreeTest.Localization;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;

namespace DecisionTreeTest.Menus;

public class DecisionTreeTestMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context) {
        if (context.Menu.Name == StandardMenus.Main) {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context) {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<DecisionTreeTestResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                DecisionTreeTestMenus.Home,
                l["Menu:Home"],
                "/mainpage",
                icon: "fas fa-home",
                order: 0
            )
        );
        
        context.Menu.Items.Insert(
			1,
			new ApplicationMenuItem(
				DecisionTreeTestMenus.Editor,
				l["Menu:Editor"],
				"/editors/editor",
				icon: "fas fa-home",
				order: 1
			)
		);

		if (DecisionTreeTestModule.IsMultiTenant) {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        return Task.CompletedTask;
    }
}