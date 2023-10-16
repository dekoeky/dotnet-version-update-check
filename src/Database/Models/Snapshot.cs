using Wvk.Dotnet.UpdateCheck.Models.General;

public class Snapshot
{
    public int Id { get;set; }
    public DateTime Created { get;set; }
    public ICollection<ReleaseIndex> Releases { get; set; } = null!;
}
