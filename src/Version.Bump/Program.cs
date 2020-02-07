using System;
using CommandLine;
using CommandLine.Text;
using Version.Bump.Commands;
using Version.Bump.IO;

namespace Version.Bump
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser(settings =>
            {
                settings.HelpWriter = Console.Error;
                settings.CaseInsensitiveEnumValues = true;
            });
            var result = parser.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    if (DirectoryExplorer.DoesCsProjExistInFolder(o.Path, out var csProjPath))
                    {
                        ProjectFileParser.ReadFileAndUpdateVersion(csProjPath, o.VersionType);
                    }
                    else
                    {
                        Console.WriteLine("No csproj found in directory.");
                        Main(new string[] {});
                    }
                });
        }
    }
}
