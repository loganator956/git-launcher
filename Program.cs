using System.Diagnostics;

string gitBashPath = Path.Combine(Directory.GetCurrentDirectory(), "git-bash.exe");
string homeDirectory = Path.Combine(Directory.GetCurrentDirectory(), "home");
try
{
    if (!File.Exists(gitBashPath))
        throw new FileNotFoundException($"Can't find git-bash.exe at {gitBashPath}");
    else if (!Directory.Exists(homeDirectory))
        throw new DirectoryNotFoundException($"Can't find home directory at {homeDirectory}");
}
catch (IOException except)
{
    Console.WriteLine(except.ToString());
    Environment.Exit(1);
}

ProcessStartInfo startInfo = new ProcessStartInfo(gitBashPath);
startInfo.EnvironmentVariables["HOME"] = homeDirectory;
startInfo.ArgumentList.Add("--cd-to-home");
foreach (string arg in args)
    startInfo.ArgumentList.Add(arg);
Process.Start(startInfo);