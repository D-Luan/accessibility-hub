namespace AccessibilityHub.Entities.Models;

public class Disability
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public virtual ICollection<Provider> Providers { get; set; } = new List<Provider>();
}
