using System;

namespace Version.Bump.Version
{
    public enum VersionType
    {
        Patch, Minor, Major
    }

    public static class VersionTypeExtensions
    {
        public static string StringValue(this VersionType versionType) => versionType switch
        {
            VersionType.Patch => "patch",
            VersionType.Minor => "minor",
            VersionType.Major => "major",
            _ => throw new ArgumentException("version type not supported")
        };
    }
}