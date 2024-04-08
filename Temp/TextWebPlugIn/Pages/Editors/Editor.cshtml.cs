using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TextWebPlugIn.ViewModels;

namespace TextWebPlugIn.Pages.Editors;

[IgnoreAntiforgeryToken]
public class EditorModel : PageModel { 
    [BindProperty]
    public CmsViewModel? CmsViewModel { get; set; }

    public void OnGet() {
    }

    public IActionResult OnPost() {
        if (!ModelState.IsValid) {
            return Page();
        }

        // Aqui você pode adicionar o código para salvar cmsViewModel no banco de dados

        return RedirectToPage("./Index");
    }
}