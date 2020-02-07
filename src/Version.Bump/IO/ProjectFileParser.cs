using System;
using System.Xml;
using Version.Bump.Version;

namespace Version.Bump.IO
{
    public static class ProjectFileParser
    {
        public static void ReadFileAndUpdateVersion(string filePath, VersionType versionBump)
        {
            var document = new XmlDocument();
            document.Load(filePath);
            var versionNode = GetVersionNode(document);
            if (versionNode is null)
            {
                throw new MissingFieldException("cs proj has no package version element");
            }

            var currentVersion = versionNode.InnerXml;
            var upgradedVersion = GetUpgradedVersion(currentVersion, versionBump);

            versionNode.InnerXml = upgradedVersion;
            document.Save(filePath);
            Console.WriteLine($"{currentVersion} -> {upgradedVersion}");
        }

        private static XmlNode? GetVersionNode(XmlDocument document)
        {
            var propertyGroupNodes = document.SelectNodes("/Project/PropertyGroup");
            if (propertyGroupNodes.Count == 0)
            {
                return null;
            }

            foreach (XmlNode proprtyGroupNode in propertyGroupNodes)
            {
                var versionNode = proprtyGroupNode.SelectSingleNode("Version");
                if (versionNode != null)
                {
                    return versionNode;
                }
            }

            return null;
        }

        private static string GetUpgradedVersion(string version, VersionType versionBump)
        {
            var currentVersion = PackageVersion.FromString(version);
            var newVersion = currentVersion.BumpVersion(versionBump);
            return newVersion.Serialize();
        }
    }
}