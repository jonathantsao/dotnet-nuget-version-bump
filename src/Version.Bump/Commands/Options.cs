using CommandLine;
using Version.Bump.Version;

namespace Version.Bump.Commands
{
    public class Options
    {
        [Value(1, MetaName = "path", HelpText = "path to folder containing csproj file", Default = "./")]
        public string Path { get; set; }
        [Value(0, MetaName = "version type", HelpText = "patch | minor | major", Required = true)]
        public VersionType VersionType { get; set; }

    }
}