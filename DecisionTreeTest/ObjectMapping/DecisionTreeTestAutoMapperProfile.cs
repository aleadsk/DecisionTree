using AutoMapper;
using DecisionTreeTest.Entities;
using DecisionTreeTest.Services.Dtos;

namespace DecisionTreeTest.ObjectMapping;

public class DecisionTreeTestAutoMapperProfile : Profile {
    public DecisionTreeTestAutoMapperProfile() {
		/* Create your AutoMapper object mappings here */
		CreateMap<CmsEntity, CmsEntityDto>().ReverseMap();
	}
}