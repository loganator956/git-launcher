using System.Diagnostics;

ProcessStartInfo startInfo = new ProcessStartInfo(Path.Combine(Directory.GetCurrentDirectory(), "git-bash.exe"));
startInfo.EnvironmentVariables["HOME"] = Path.Combine(Directory.GetCurrentDirectory(), "home");
Console.WriteLine(startInfo.EnvironmentVariables["HOME"]);
startInfo.ArgumentList.Add("--cd-to-home");
foreach (string arg in args)
    startInfo.ArgumentList.Add(arg);
Process.Start(startInfo);