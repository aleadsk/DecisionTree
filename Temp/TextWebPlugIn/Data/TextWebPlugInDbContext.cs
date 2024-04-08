using MongoDB.Driver;
using TextWebPlugIn.Model;
using Volo.Abp.MongoDB;

namespace TextWebPlugIn.Data;

public class TextWebPlugInDbContext : AbpMongoDbContext {
	/* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */
	public IMongoCollection<CmsEntity> CmsEntities => Collection<CmsEntity>();

	protected override void CreateModel(IMongoModelBuilder modelBuilder) {
		base.CreateModel(modelBuilder);
	}
}