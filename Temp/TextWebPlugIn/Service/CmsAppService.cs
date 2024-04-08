using TextWebPlugIn.Interfaces.Repository;
using TextWebPlugIn.Interfaces.Service;
using TextWebPlugIn.Interfaces.Service.Dtos;
using TextWebPlugIn.Model;

namespace TextWebPlugIn.Service;

public class CmsAppService : ICmsAppService {
	private readonly ICmsRepository _cmsRepository;

	public CmsAppService(ICmsRepository cmsRepository) {
		_cmsRepository = cmsRepository;
	}

	public async Task<List<CmsEntityDto>> GetAll() {
		List<CmsEntity> cmsEntityList = await _cmsRepository.GetAll();
        List<CmsEntityDto> cmsEntityDtoList = new();

        foreach (var dto in cmsEntityList) {
            var cmsEntityDto = new CmsEntityDto {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description
            };
            cmsEntityDtoList.Add(cmsEntityDto);
        }

        return cmsEntityDtoList; 
	}

	public Task<CmsEntityDto> GetCMSContent(Guid id) {
		throw new NotImplementedException();
	}

	public async Task<CmsEntityDto> InsertOrUpdateCMSContent(CmsEntityDto cmsEntityDto) {
		CmsEntity cmsEntity = new() { 
			Id = cmsEntityDto.Id,
			Name = cmsEntityDto.Name,
			Description = cmsEntityDto.Description,
		};

		await _cmsRepository.Create(cmsEntity);
		/*
        if (cmsEntity.Id is Guid.Empty()) {//Criar extensão
			cmsEntity = await _cmsRepository.Create(cmsEntity);
        } else {
			cmsEntity = await _cmsRepository.Update(cmsEntity);
		}         */

		return cmsEntityDto;
	}
}