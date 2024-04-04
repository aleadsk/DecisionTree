using DecisionTreeTest.Services.Dtos;

namespace DecisionTreeTest.Interfaces.Service;

public interface ICmsAppService {
	Task<CmsEntityDto> InsertOrUpdateCMSContent(CmsEntityDto cmsEntity);

	Task<CmsEntityDto> GetCMSContent(Guid id);

    Task<List<CmsEntityDto>> GetAll();
}