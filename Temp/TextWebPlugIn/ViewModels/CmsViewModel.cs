using Microsoft.AspNetCore.Mvc;

namespace TextWebPlugIn.ViewModels;

public class CmsViewModel {
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
}