using System.Diagnostics;

ProcessModule? module = Process.GetCurrentProcess().MainModule;
if (module is null)
    throw new NullReferenceException("MainModule of current process is null");

Console.WriteLine($"git-launcher version {module.FileVersionInfo.FileVersion}\n");

string currentExe = module.FileName ?? String.Empty;
string currentExeDirectory = Path.GetDirectoryName(currentExe) ?? String.Empty;

string gitBashPath = Path.Combine(currentExeDirectory, "git-bash.exe");
string homeDirectory = Path.Combine(currentExeDirectory, "home");
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