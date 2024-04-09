using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TextWebPlugIn.Interfaces.Service;
using TextWebPlugIn.Interfaces.Service.Dtos;
using TextWebPlugIn.ViewModels;

namespace TextWebPlugIn.Pages.Editors;

[IgnoreAntiforgeryToken]
public class EditorModel : PageModel {
    [BindProperty]
    public CmsViewModel? CmsViewModel { get; set; } = new();

    private readonly ICmsAppService _cmsAppService;
    private readonly IMapper _mapper;

    public EditorModel(ICmsAppService cmsAppService, IMapper mapper) {
        _cmsAppService = cmsAppService;
        _mapper = mapper;
    }

    public async void OnGet() {
        //TODO Receber Guid
        CmsEntityDto? cmsEntityDto = (await _cmsAppService.GetAll()).FirstOrDefault();

        var result = await _cmsAppService.GetCMSContent(cmsEntityDto.Id);

        if (result is not null) { 
            CmsViewModel = _mapper.Map<CmsViewModel>(result);
        }
    }

    public async Task<IActionResult> OnPost() {
        if (!ModelState.IsValid) {
            return Page();
        }

        if (CmsViewModel is not null) {
            CmsEntityDto cmsEntityDto = _mapper.Map<CmsEntityDto>(CmsViewModel);

            await _cmsAppService.InsertOrUpdateCMSContent(cmsEntityDto);
        }

        return RedirectToPage("./mainpage");
    }
}