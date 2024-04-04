using DecisionTreeTest.Entities;
using Volo.Abp.Application.Services;

namespace DecisionTreeTest.Interfaces.Repository;

public interface ICmsRepository : IApplicationService {
    Task<CmsEntity> GetById(Guid id);

    Task<List<CmsEntity>> GetAll();

    Task<CmsEntity> Create(CmsEntity entity);

    Task<CmsEntity> Update(CmsEntity entity);
}