using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TextWebPlugIn.Interfaces.Service;
using TextWebPlugIn.Interfaces.Service.Dtos;
using TextWebPlugIn.ViewModels;

namespace TextWebPlugIn.Pages;
public class MainPageModel : PageModel {
    private readonly ICmsAppService _cmsAppService;
    private readonly IMapper _mapper;

    [BindProperty]
    public List<CmsViewModel>? CmsViewModelList { get; set; } = new();

    public MainPageModel(ICmsAppService cmsAppService, IMapper mapper) {
        _cmsAppService = cmsAppService;
        _mapper = mapper;
    }

    public async void OnGet() { 
        List<CmsEntityDto> cmsEntityList = await _cmsAppService.GetAll();

        if (cmsEntityList is not null && cmsEntityList.Count > 0) { 
            CmsViewModelList = _mapper.Map<List<CmsViewModel>>(cmsEntityList);
        }
    }
}