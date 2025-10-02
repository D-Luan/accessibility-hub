namespace AccessibilityHub.Entities.Models;

public class Resource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    public string Category { get; set; }
    public int DisabilityId { get; set; }
    public Disability Disability { get; set; }
}
