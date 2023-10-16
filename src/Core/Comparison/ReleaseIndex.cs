using Wvk.Dotnet.UpdateCheck.Models.General;

namespace Wvk.Dotnet.UpdateCheck.Comparison;

public class ReleaseIndexComparison : IEqualityComparer<ReleaseIndex>
{
    public bool Equals(ReleaseIndex? x, ReleaseIndex? y)
    {
        if (ReferenceEquals(x, y))
            return true;

        if (ReferenceEquals(x, null))
            return false;

        if (ReferenceEquals(y, null))
            return false;

        if (x.GetType() != y.GetType())
            return false;

        return x.ChannelVersion == y.ChannelVersion
               && x.LatestRelease == y.LatestRelease
               && x.LatestReleaseDate == y.LatestReleaseDate
               && x.Security == y.Security
               && x.LatestRuntime == y.LatestRuntime
               && x.LatestSdk == y.LatestSdk
               && x.Product == y.Product
               && x.ReleaseType == y.ReleaseType
               && x.SupportPhase == y.SupportPhase
               && x.EolDate == y.EolDate
               && x.ReleasesJson == y.ReleasesJson;
    }

    public int GetHashCode(ReleaseIndex obj)
    {
        var hashCode = new HashCode();
        hashCode.Add(obj.ChannelVersion);
        hashCode.Add(obj.LatestRelease);
        hashCode.Add(obj.LatestReleaseDate);
        hashCode.Add(obj.Security);
        hashCode.Add(obj.LatestRuntime);
        hashCode.Add(obj.LatestSdk);
        hashCode.Add(obj.Product);
        hashCode.Add(obj.ReleaseType);
        hashCode.Add(obj.SupportPhase);
        hashCode.Add(obj.EolDate);
        hashCode.Add(obj.ReleasesJson);
        return hashCode.ToHashCode();
    }
}
