
using SystemInfo.Processes;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var listProcesses = new ListProcesses();

            for (int i = 0; i < listProcesses.Length; i++)
            {
                Console.WriteLine($"{listProcesses[i].Id:d8} | {listProcesses[i].Handle:d8} | {listProcesses[i].Name.PadRight(50 , ' ')} |");
            }
            Console.WriteLine($"{listProcesses.Length}");
            Console.ReadLine();
        }
    }
}