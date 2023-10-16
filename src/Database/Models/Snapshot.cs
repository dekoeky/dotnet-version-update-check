using System.ComponentModel.DataAnnotations.Schema;
using Wvk.Dotnet.UpdateCheck.Models.General;

public class Snapshot
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get;set; }
    public DateTime Created { get;set; }
    public ICollection<ReleaseIndex> Releases { get; set; } = null!;
}
