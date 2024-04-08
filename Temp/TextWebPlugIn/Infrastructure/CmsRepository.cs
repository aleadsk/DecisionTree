using TextWebPlugIn.Interfaces.Repository;
using TextWebPlugIn.Model;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TextWebPlugIn.Infrastructure;

public class CmsRepository : ApplicationService, ICmsRepository {
    private readonly IRepository<CmsEntity, Guid> _cmsRepository;
    public CmsRepository(IRepository<CmsEntity, Guid> cmsRepository) {
        _cmsRepository = cmsRepository;
    }

    //public Task<CmsEntity> Create(CmsEntity entity)
    //{
    //	throw new NotImplementedException();
    //}

    //public Task<List<CmsEntity>> GetAll()
    //{
    //	throw new NotImplementedException();
    //}

    //public Task<CmsEntity> GetById(Guid id)
    //{
    //	throw new NotImplementedException();
    //}

    //public Task<CmsEntity> Update(CmsEntity entity)
    //{
    //	throw new NotImplementedException();
    //}
    public async Task<CmsEntity> Create(CmsEntity entity) {
        return await _cmsRepository.InsertAsync(entity);
    }

    public async Task<List<CmsEntity>> GetAll() {
        return await _cmsRepository.GetListAsync();
    }

    public async Task<CmsEntity> GetById(Guid id) {
        return await _cmsRepository.GetAsync(x => x.Id == id);
    }

    public async Task<CmsEntity> Update(CmsEntity entity) {
        return await _cmsRepository.UpdateAsync(entity);
    }
}