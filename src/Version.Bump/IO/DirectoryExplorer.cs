using System.IO;
using System.Linq;

namespace Version.Bump.IO
{
    public class DirectoryExplorer
    {
        public static bool DoesFileExist(string fullPath) => File.Exists(fullPath);
        public static bool DoesDirectoryExist(string fullPath) => Directory.Exists(fullPath);
        public static bool DoesCsProjExistInFolder(string folderPath, out string csProjPath)
        {
            var filesInFolder = Directory.GetFiles(folderPath);
            var csProjPaths = filesInFolder.Where(p => p.EndsWith(".csproj"));
            if (csProjPaths.Any())
            {
                csProjPath = GetFullPath(csProjPaths.First());
                return true;
            }

            csProjPath = null;
            return false;
        }
        public static string GetFullPath(string relativePath) => Path.GetFullPath(relativePath);
    }
}