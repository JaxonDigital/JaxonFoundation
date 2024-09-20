namespace JaxonFoundation.Logic.Interfaces
{
    public interface MediaFile
    {
        string? FileSize { get; set; }
        string? FileType { get; set; }
        string? DisplayName { get; set; }
        string? Description { get; set; }
    }
}
