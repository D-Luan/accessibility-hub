namespace AccessibilityHub.WebApp.Dtos
{
    public class ResourceDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string Url { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;
    }
}