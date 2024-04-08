using Volo.Abp.Domain.Entities;

namespace TextWebPlugIn.Model;

public class CmsEntity : IEntity<Guid> {
	public Guid Id { get; set; }

	public string? Name { get; set; }

	public string? Description { get; set; }

	public object?[] GetKeys() {
		return new object[] { Id };
	}
}