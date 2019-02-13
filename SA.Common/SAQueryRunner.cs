using System.Diagnostics;

namespace SA.Common
{
    public class SAQueryRunner
    {
        public static void Run(string inputPath, string outputPath, string saRunner, string saProject)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"C:\windows\system32\CMD.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.Arguments = $" /c cd \"{outputPath}\" & \"{saRunner}\" localrun -Project \"{saProject}\" -OutputPath {outputPath}";

            Process exeProcess = Process.Start(startInfo);
            exeProcess.WaitForExit();
        }
    }
}
