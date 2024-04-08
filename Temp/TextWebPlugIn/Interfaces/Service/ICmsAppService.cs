using TextWebPlugIn.Interfaces.Service.Dtos;

namespace TextWebPlugIn.Interfaces.Service;

public interface ICmsAppService {
	Task<CmsEntityDto> InsertOrUpdateCMSContent(CmsEntityDto cmsEntity);

	Task<CmsEntityDto> GetCMSContent(Guid id);

	Task<List<CmsEntityDto>> GetAll();
}