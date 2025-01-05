using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace De.HsFlensburg.ClientApp112.Services.ValidationService
{
    public class WingetValidationService
    {
        /// <summary>
        /// Ruft "winget search <packageId>" auf und schaut,
        /// ob es einen Treffer gibt.
        /// Wirft ggf. Ausnahmen, wenn winget nicht verfügbar ist.
        /// </summary>
        public bool ValidatePackageId(string packageId, out string message)
        {
            if (string.IsNullOrWhiteSpace(packageId))
            {
                message = "Package-ID ist leer oder ungültig.";
                return false;
            }

            try
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = "winget",
                    Arguments = $"search \"{packageId}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using var process = new Process();
                process.StartInfo = startInfo;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string errorOutput = process.StandardError.ReadToEnd();

                process.WaitForExit();

                // 1) Falls "No package found" in Output, => false
                if (output.Contains("No package found", StringComparison.OrdinalIgnoreCase))
                {
                    message = $"Kein Winget-Paket unter \"{packageId}\" gefunden.";
                    return false;
                }

                // 2) Ggf. Winget-Fehlermeldung?
                if (!string.IsNullOrWhiteSpace(errorOutput))
                {
                    // Falls "winget" gar nicht vorhanden ist oder
                    // was Anderes schiefläuft
                    message = $"Winget-Fehler: {errorOutput}";
                    return false;
                }

                // 3) Wenn wir bis hierhin kommen und "No package found"
                //    nicht auftaucht, nehmen wir an, es gibt einen Treffer.
                message = $"Paket \"{packageId}\" wurde gefunden.";
                return true;
            }
            catch (Exception ex)
            {
                // Z.B. wenn winget nicht installiert ist
                message = $"Fehler beim Aufruf von winget: {ex.Message}";
                return false;
            }
        }
    }
}
