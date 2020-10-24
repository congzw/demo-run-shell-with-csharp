using System.Diagnostics;
using System.IO;

namespace NbSites.Web.Helpers
{
    public class ShellHelper
    {
        public string RunFile(string dir, string fileName, string arguments)
        {
            var fullFilePath = Path.Combine(dir, fileName);
            if (!File.Exists(fullFilePath))
            {
                return "shell run failed: not exist: " + fullFilePath;
            }

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fullFilePath,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            process.Start();

            //var result = process.StandardOutput.ReadToEnd();

            //解决中文乱码的问题
            using var reader = new StreamReader(process.StandardOutput.BaseStream, System.Text.Encoding.UTF8, true);
            reader.BaseStream.Flush();
            var result = reader.ReadToEnd();

            process.WaitForExit();
            return result;
        }
    }
}
