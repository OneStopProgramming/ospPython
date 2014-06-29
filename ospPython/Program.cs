using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ospPython
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = ConfigurationManager.AppSettings["pythonPath"];
            string commandArg;

            if (command == "")
                return;

            //Verify exe exists
            if (!File.Exists(command))
            {
                Console.WriteLine("Error: The python.exe was not found.");
                Console.WriteLine("You must specify the path to the python.exe in the ospPython.exe.config file");
                Console.WriteLine("Open the ospPython.exe.config file with a text editior and specify the path to python.exe");
                Console.WriteLine("Example:C:\\Python33\\python.exe");
                Console.WriteLine();
                Console.WriteLine("Verify that ospPython.exe.config exists");
                Console.WriteLine("This .config file must be located in the same folder as ospPython.exe");
                Console.WriteLine("ospPython.exe.config can be downloaded from https://github.com/OneStopProgramming/ospPython.");
                
                return;
            }
            if (args.Length != 1)
            {
                commandArg = "";

            }
            else
            {
                commandArg = args[0];
            }

            Console.WriteLine(command + " " + commandArg);

            Process process = new Process();
            process.StartInfo.FileName = command;
            process.StartInfo.Arguments = commandArg;
            try
            {
                process.Start();
            }
            catch
            {
                Console.WriteLine("Error: An unknown error has occured in ospPython.");
                Console.WriteLine("    Ussage: ospPython path\\to\\yourPythonScript.py");
                Console.WriteLine("    Example: ospPython HelloWorld.py");
                Environment.Exit(1);
            }
            return;
        }
    }
}
