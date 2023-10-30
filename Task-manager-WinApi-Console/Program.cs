using SystemInfo.Processes;
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
                Console.WriteLine($"{listProcesses[i].Id,+6} | {listProcesses[i].Handle,+6} | {listProcesses[i].Name,-50} | {(listProcesses[i].Memory.WorkingSetSize / 1024),+8} КБ ");
            }

            Console.WriteLine($"{listProcesses.Length}");
            var h = new IntPtr(Convert.ToInt64(Console.ReadLine()));

            PTAPI.TerminateProcess(h, 100);
        }
    }
}