using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace TextWebPlugIn.Model;

public class CmsEntity : IEntity<Guid> {
	public Guid Id { get; set; }

    [MaxLength(50)]
    public string? Name { get; set; }

    [MaxLength(10000)]
    public string? Description { get; set; }

	public object?[] GetKeys() {
		return new object[] { Id };
	}
}