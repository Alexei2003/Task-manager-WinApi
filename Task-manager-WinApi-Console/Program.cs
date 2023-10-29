
using SystemInfo.Processes;
using SystemInfo.Processes.WinApi.PSAPI;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var listProcesses = new ListProcesses();

            for(int i  = 0; i < listProcesses.Length; i++)
            {
                Console.WriteLine($"{listProcesses[i].Id:d8} | {listProcesses[i].Handle:d8} |");
            }

            Console.ReadLine();
        }
    }
}