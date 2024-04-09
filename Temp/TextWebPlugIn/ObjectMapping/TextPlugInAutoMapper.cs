using AutoMapper;
using TextWebPlugIn.Interfaces.Service.Dtos;
using TextWebPlugIn.Model;
using TextWebPlugIn.ViewModels;

namespace TextWebPlugIn.ObjectMapping;

public class TextPlugInAutoMapper : Profile {
    public TextPlugInAutoMapper() {
        /* Create your AutoMapper object mappings here */
        CreateMap<CmsEntity, CmsEntityDto>().ReverseMap();
        CreateMap<CmsEntityDto, CmsViewModel>().ReverseMap();
    }
}