using AutoMapper;
using TextWebPlugIn.Interfaces.Repository;
using TextWebPlugIn.Interfaces.Service;
using TextWebPlugIn.Interfaces.Service.Dtos;
using TextWebPlugIn.Model;
using TextWebPlugIn.Extensions;

namespace TextWebPlugIn.Service;

public class CmsAppService : ICmsAppService {
	private readonly ICmsRepository _cmsRepository;
	private readonly IMapper _mapper;

	public CmsAppService(ICmsRepository cmsRepository, IMapper mapper) {
		_cmsRepository = cmsRepository;
		_mapper = mapper;
	}

	public async Task<List<CmsEntityDto>> GetAll() {
		List<CmsEntity> cmsEntityList = await _cmsRepository.GetAll();
        List<CmsEntityDto> cmsEntityDtoList = _mapper.Map<List<CmsEntityDto>>(cmsEntityList);

        return cmsEntityDtoList; 
	}

	public async Task<CmsEntityDto> GetCMSContent(Guid id) {
		CmsEntity cmsEntity = await _cmsRepository.GetById(id);

		if (cmsEntity is null) return new();

        return _mapper.Map<CmsEntityDto>(cmsEntity);
    }

	public async Task<CmsEntityDto> InsertOrUpdateCMSContent(CmsEntityDto cmsEntityDto) {
		CmsEntity cmsEntity = _mapper.Map<CmsEntity>(cmsEntityDto);

		if (cmsEntity.Id.IsEmpty()) {
			cmsEntity = await _cmsRepository.Create(cmsEntity);
		}
		else {
			cmsEntity = await _cmsRepository.Update(cmsEntity);
		}

		return cmsEntityDto;
	}
}