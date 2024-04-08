using TextWebPlugIn.Model;
using Volo.Abp.Application.Services;

namespace TextWebPlugIn.Interfaces.Repository;

public interface ICmsRepository : IApplicationService {
	Task<CmsEntity> GetById(Guid id);

	Task<List<CmsEntity>> GetAll();

	Task<CmsEntity> Create(CmsEntity entity);

	Task<CmsEntity> Update(CmsEntity entity);
}