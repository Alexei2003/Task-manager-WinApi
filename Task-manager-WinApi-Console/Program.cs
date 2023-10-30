
using SystemInfo.Processes;
using SystemInfo.Processes.WinApi.PSAPI;
using SystemInfo.Processes.WinApi.PTAPI;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var listProcesses = new ListProcesses();

            for (int i = 0; i < listProcesses.Length; i++)
            {
                Console.WriteLine($"{listProcesses[i].Id:d8} | {listProcesses[i].Handle:d8} | {listProcesses[i].Name,-50} | {(listProcesses[i].Memory/1024):d10}");
            }
            Console.WriteLine($"{listProcesses.Length}");
            var h = new IntPtr(Convert.ToInt64(Console.ReadLine()));

            PTAPI.TerminateProcess(h, 1);
        }
    }
}