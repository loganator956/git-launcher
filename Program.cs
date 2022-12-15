using System.Diagnostics;

ProcessStartInfo startInfo = new ProcessStartInfo(Path.Combine(Directory.GetCurrentDirectory(), "git-bash.exe"));
startInfo.EnvironmentVariables["HOME"] = Path.Combine(Directory.GetCurrentDirectory(), "home");
Console.WriteLine(startInfo.EnvironmentVariables["HOME"]);
startInfo.Arguments = "--cd-to-home";
Process.Start(startInfo);