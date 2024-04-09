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

    public async Task<CmsEntity> Create(CmsEntity entity) {
        try {
            return await _cmsRepository.InsertAsync(entity);
        }
        catch (Exception ex) {
            throw new Exception("Error in Create a new Text", ex);
        }
    }

    public async Task<List<CmsEntity>> GetAll() {
        try {
            return await _cmsRepository.GetListAsync();
        }
        catch (Exception ex) {
            throw new Exception("Error in Get all Texts", ex);
        }
    }

    public async Task<CmsEntity> GetById(Guid id) {
        try {
            return await _cmsRepository.GetAsync(x => x.Id == id);
        }
        catch (Exception ex) {
            throw new Exception($"Erro in Get id: {id}", ex);
        }
    }

    public async Task<CmsEntity> Update(CmsEntity entity) {
        try {
            return await _cmsRepository.UpdateAsync(entity);
        }
        catch (Exception ex) {
            throw new Exception("Erro in Update Text", ex);
        }
    }
}