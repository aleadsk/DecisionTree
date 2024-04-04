using AutoMapper;
using DecisionTreeTest.Entities;
using DecisionTreeTest.Interfaces.Repository;
using DecisionTreeTest.Interfaces.Service;
using DecisionTreeTest.Services.Dtos;
using Volo.Abp.Domain.Entities;

namespace DecisionTreeTest.Services;

public class CmsAppService : ICmsAppService {
    private readonly ICmsRepository _cmsRepository;
    private readonly IMapper _mapper;
    public CmsAppService(ICmsRepository cmsRepository, IMapper mapper) {
        _cmsRepository = cmsRepository;
        _mapper = mapper;
    }
    public Task<List<CmsEntityDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<CmsEntityDto> GetCMSContent(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<CmsEntityDto> InsertOrUpdateCMSContent(CmsEntityDto cmsEntityDto) {
        CmsEntity cmsEntity = new();
        if (cmsEntityDto is not null) cmsEntity = _mapper.Map<CmsEntityDto, CmsEntity>(cmsEntityDto);

		cmsEntity = await _cmsRepository.Create(cmsEntity);
		/*
        if (cmsEntity.Id is Guid.Empty()) {//Criar extensão
			cmsEntity = await _cmsRepository.Create(cmsEntity);
        } else {
			cmsEntity = await _cmsRepository.Update(cmsEntity);
		}         */

		return cmsEntityDto;
    }
}