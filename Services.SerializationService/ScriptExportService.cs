using De.HsFlensburg.ClientApp112.Business.Model.BusinessObjects;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace De.HsFlensburg.ClientApp112.Services.ScriptExport
{
    public class ScriptExportService
    {
        public void ExportAsWingetScript(PackageCollection packages, string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            var lines = new List<string>();

            if (extension == ".bat")
            {
                lines.Add("@echo off");
                lines.Add(":: ========================================");
                lines.Add(":: Winget Install Script (Generated)");
                lines.Add(":: ========================================");
                lines.Add("");
            }
            else
            {
                // Falls .txt
                lines.Add("### Winget Install Script (Generated)");
                lines.Add("");
            }

            foreach (var pkg in packages)
            {
                lines.Add(BuildEchoLine(pkg, extension));
                lines.Add(BuildWingetCommand(pkg));
                lines.Add("");
            }
            if (extension == ".bat")
            {
                lines.Add("echo All packages installed!");
                lines.Add("pause");
            }

            File.WriteAllLines(filePath, lines, Encoding.UTF8);
        }

        private string BuildEchoLine(Package pkg, string extension)
        {
            string pkgName = string.IsNullOrWhiteSpace(pkg.Name)
                ? pkg.PackageId
                : pkg.Name;

            if (extension == ".bat")
            {
                return $"echo Installing {EscapeBatch(pkgName)} ...";
            }
            else
            {
                return $"Installing {pkgName}...";
            }
        }

        private string BuildWingetCommand(Package pkg)
        {
            var sb = new StringBuilder("winget install ");
            sb.Append($"\"{pkg.PackageId}\" ");

            if (pkg.InstallOptions.IsSilent) sb.Append("--silent ");
            if (pkg.InstallOptions.Force) sb.Append("--force ");

            if (!string.IsNullOrWhiteSpace(pkg.InstallOptions.Scope))
                sb.Append($"--scope {pkg.InstallOptions.Scope} ");
            if (!string.IsNullOrWhiteSpace(pkg.InstallOptions.Location))
                sb.Append($"--location \"{pkg.InstallOptions.Location}\" ");
            if (!string.IsNullOrWhiteSpace(pkg.InstallOptions.Version))
                sb.Append($"--version {pkg.InstallOptions.Version} ");
            if (!string.IsNullOrWhiteSpace(pkg.InstallOptions.DependencySource))
                sb.Append($"--dependency-source {pkg.InstallOptions.DependencySource} ");
            if (!string.IsNullOrWhiteSpace(pkg.InstallOptions.CustomArguments))
                sb.Append($"{pkg.InstallOptions.CustomArguments} ");

            return sb.ToString().Trim();
        }

        private string EscapeBatch(string text)
        {
            return text
                .Replace("%", "%%")
                .Replace("&", "^&");
        }
    }
}
