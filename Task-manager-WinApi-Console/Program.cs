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
                Console.WriteLine($"{listProcesses[i].Id,+6} | {listProcesses[i].Handle,+6} | {listProcesses[i].Name,-50} | {(listProcesses[i].Memory.WorkingSetSize / 1024),+8} КБ ");
            }

            Console.WriteLine($"{listProcesses.Length}");
        }
    }
}