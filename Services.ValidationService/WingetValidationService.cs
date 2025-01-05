using System;
using System.Diagnostics;

namespace De.HsFlensburg.ClientApp112.Services.ValidationService
{
    public class WingetValidationService
    {
        public bool ValidatePackageId(string packageId, out string message)
        {
            if (string.IsNullOrWhiteSpace(packageId))
            {
                message = "Es wurde kein Paketauswahlargument angegeben";
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

                using (var process = new Process())
                {
                    process.StartInfo = startInfo;
                    process.Start();

                    string output = process.StandardOutput.ReadToEnd();
                    string errorOutput = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    if (output.IndexOf("Es wurde kein Paket gefunden", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        message = $"Kein Winget-Paket unter \"{packageId}\" gefunden.";
                        return false;
                    }

                    if (!string.IsNullOrWhiteSpace(errorOutput))
                    {
                        message = $"Winget-Fehler: {errorOutput}";
                        return false;
                    }

                    message = $"Paket \"{packageId}\" wurde gefunden.";
                    return true;
                }
            }
            catch (Exception ex)
            {
                message = $"Fehler beim Aufruf von winget: {ex.Message}";
                return false;
            }
        }

    }
}
