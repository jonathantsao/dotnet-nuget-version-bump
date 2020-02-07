using System;
using Version.Bump.Version;
using Xunit;

namespace Version.Bump.VersionManipulation.Tests
{
    public class VersionManipulationTests
    {
        [Fact]
        public void PatchUpdateTest()
        {
            var version = PackageVersion.FromString("1.2.10");
            var patch = version.BumpVersion(VersionType.Patch);

            Assert.Equal(new PackageVersion(1, 2, 11), patch);
        }

        [Fact]
        public void MinorUpdateTest()
        {
            var version = PackageVersion.FromString("1.2.10");
            var minor = version.BumpVersion(VersionType.Minor);

            Assert.Equal(new PackageVersion(1, 3, 0), minor);
        }

        [Fact]
        public void MajorUpdateTest()
        {
            var version = PackageVersion.FromString("1.2.200");
            var major = version.BumpVersion(VersionType.Major);

            Assert.Equal(new PackageVersion(2, 0, 0), major);
        }
    }
}
