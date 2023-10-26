using System.Diagnostics;
using TechTalk.SpecFlow;

namespace PocTest.Hooks
{
    [Binding]
    public static class BaseHook
    {
        public static string dateTimeNow = DateTime.UtcNow.ToString("yyyy_MM_dd__HH_mm_sss");

        [AfterTestRun]
        public static void AfterTestRun()
        {
            var reportTitle = "Testes";

            var workingDirectory = Directory.GetCurrentDirectory();
            var currentDir = Directory.GetParent(workingDirectory)?.FullName;
            var projectDir = Directory.GetParent(currentDir!)?.Parent?.FullName;

            var command = @" feature-folder " + @projectDir + @"/ -t " + @workingDirectory
                + "/TestExecution.json --project-name \"Plataforma-API\" --title \""
                + @reportTitle + "\" --output " + @workingDirectory + @"/LivingDoc.html";

            try
            {
                Process proc = new Process();
                proc.StartInfo.FileName = "/Users/sr_iteris_imacedo/.dotnet/tools/livingdoc";
                proc.StartInfo.Arguments = command;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.UseShellExecute = false;
                proc.Start();
                string mainOutPut = proc.StandardOutput.ReadToEnd();
                string errorOuput = proc.StandardError.ReadToEnd();

                Console.WriteLine("Standard Out put: " + mainOutPut + System.Environment.NewLine +
                    "Error Output: " + errorOuput + System.Environment.NewLine + proc.ExitCode);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                string folderDestination = $@"{projectDir}\TestResultsLivingDoc";

                if (!Directory.Exists(folderDestination))
                    Directory.CreateDirectory(folderDestination);

                File.Copy($@"{workingDirectory}\LivingDoc.html", $@"{folderDestination}\{dateTimeNow}.html");
            }
        }
    }
}