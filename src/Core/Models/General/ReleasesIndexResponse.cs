using System.Collections;
using System.Text.Json.Serialization;

namespace Wvk.Dotnet.UpdateCheck.Models.General;

public class ReleasesIndexResponse : IEnumerable<ReleaseIndex>
{
    [JsonPropertyName("$schema")]
    public required string Schema { get; set; }

    [JsonPropertyName("releases-index")]
    public required ReleaseIndex[] ReleasesIndex { get; set; }

    public IEnumerator<ReleaseIndex> GetEnumerator() => ((IEnumerable<ReleaseIndex>)ReleasesIndex).GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
