using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp112.Services
{
    public static class PathHelper
    {

        public static string TryGetSolutionDirectoryParentString(string currentPath = null)
        {
            var directory = new DirectoryInfo(currentPath ?? Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }
            return directory?.FullName;
        }

        public static string GetAwpAppDataDirectory()
        {
            var solutionDir = TryGetSolutionDirectoryParentString();
            if (string.IsNullOrEmpty(solutionDir))
            {
                return Path.Combine(Directory.GetCurrentDirectory(), "AwpAppData");
            }
            return Path.Combine(solutionDir, "AwpAppData");
        }
    }
}