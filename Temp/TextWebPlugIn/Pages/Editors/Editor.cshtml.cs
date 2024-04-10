using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TextWebPlugIn.Extensions;
using TextWebPlugIn.Interfaces.Service;
using TextWebPlugIn.Interfaces.Service.Dtos;
using TextWebPlugIn.ViewModels;

namespace TextWebPlugIn.Pages.Editors;

[IgnoreAntiforgeryToken]
public class EditorModel : PageModel {
    [BindProperty]
    public CmsViewModel? CmsViewModel { get; set; } = new(); 
    public bool ShowErrorModal { get; set; }

    private readonly ICmsAppService _cmsAppService;
    private readonly IMapper _mapper;

    public EditorModel(ICmsAppService cmsAppService, IMapper mapper) {
        _cmsAppService = cmsAppService;
        _mapper = mapper;
    }

    public async void OnGet(Guid id) {
        CmsEntityDto cmsEntityDto = new();

        if (!id.IsEmpty()) {
            cmsEntityDto = await _cmsAppService.GetCMSContent(id);
        }

        if (!cmsEntityDto.Id.IsEmpty()) { 
            CmsViewModel = _mapper.Map<CmsViewModel>(cmsEntityDto);
        }
    }

    public async Task<IActionResult> OnPost() {
        if (!ModelState.IsValid) {
            return BadRequest("Fail to save data, your data is not correct!");
        }

        string errorMessage; 
        if (!TextExtensions.ValidateMaxLength(CmsViewModel.Description, 10000, out errorMessage)) {
            ShowErrorModal = true; 
            return Page();
        }

        if (CmsViewModel is not null) {
            CmsEntityDto cmsEntityDto = _mapper.Map<CmsEntityDto>(CmsViewModel);

            await _cmsAppService.InsertOrUpdateCMSContent(cmsEntityDto);
        }

        return RedirectToPage("./mainpage");
    }
}