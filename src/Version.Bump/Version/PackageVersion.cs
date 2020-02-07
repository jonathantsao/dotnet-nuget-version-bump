using System;
using System.Diagnostics.CodeAnalysis;

namespace Version.Bump.Version
{
    public class PackageVersion : IEquatable<PackageVersion>
    {
        public readonly int Patch;
        public readonly int Minor;
        public readonly int Major;

        public PackageVersion(int major, int minor, int patch)
        {
            Major = major;
            Minor = minor;
            Patch = patch;
        }

        public PackageVersion BumpVersion(VersionType versionType) => versionType switch
        {
            VersionType.Patch => new PackageVersion(Major, Minor, Patch + 1),
            VersionType.Minor => new PackageVersion(Major, Minor + 1, 0),
            VersionType.Major => new PackageVersion(Major + 1, 0, 0),
            _ => throw new ArgumentException("invalid version type")
        };

        public string Serialize() => $"{Major}.{Minor}.{Patch}";

        public static PackageVersion FromString(string version)
        {
            var versionParts = version.Split(".");
            var didParseMajor = Int32.TryParse(versionParts[0], out var major);
            var didParseMinor = Int32.TryParse(versionParts[1], out var minor);
            var didParsePatch = Int32.TryParse(versionParts[2], out var patch);

            if (didParseMajor && didParseMinor && didParsePatch)
            {
                return new PackageVersion(major, minor, patch);
            }

            throw new FormatException("invalid package format");
        }

        public bool Equals(PackageVersion other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Major.Equals(other.Major) &&
                   Minor.Equals(other.Minor) &&
                   Patch.Equals(other.Patch);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PackageVersion) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Major.GetHashCode();
                hashCode = (hashCode * 397) ^ Minor.GetHashCode();
                hashCode = (hashCode * 397) ^ Patch;
                return hashCode;
            }
        }
    }
}