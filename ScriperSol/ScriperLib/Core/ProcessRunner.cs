﻿using System;
using System.Diagnostics;

namespace ScriperLib.Core
{
    internal class ProcessRunner : IScriptRunner
    {
        public ProcessRunner()
        {
        }
        public void Run(IScript script, IOutput[] outputs)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = script.Configuration.Path,
                    CreateNoWindow = script.Configuration.RunInNewWindow,
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                }
            };

            process.OutputDataReceived += (object sender, DataReceivedEventArgs e) => Console.WriteLine("output :: " + e.Data);

            process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) => Console.WriteLine("error :: " + e.Data);

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();

            Console.WriteLine("ExitCode: {0}", process.ExitCode);
            process.Close();
        }
    }
}
