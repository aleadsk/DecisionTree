using System.ComponentModel.DataAnnotations;

namespace TextWebPlugIn.ViewModels;

public class CmsViewModel {
    public Guid Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Description { get; set; }
}