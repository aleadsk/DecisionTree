using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TextWebPlugIn.Interfaces.Service;
using TextWebPlugIn.Interfaces.Service.Dtos;
using TextWebPlugIn.ViewModels;

namespace TextWebPlugIn.Pages;
public class MainPageModel : PageModel {
    private readonly ICmsAppService _cmsAppService;

    [BindProperty]
    public List<CmsViewModel>? cmsViewModelList { get; set; } = new();

    public MainPageModel(ICmsAppService cmsAppService) {
        _cmsAppService = cmsAppService;
    }

    public async void OnGet() { 
        List<CmsEntityDto> cmsEntityList = await _cmsAppService.GetAll();

        foreach (var dto in cmsEntityList) {
            var viewModel = new CmsViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description
            };
            cmsViewModelList.Add(viewModel);
        }
    }
}