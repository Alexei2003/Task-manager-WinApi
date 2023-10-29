
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
                if(listProcesses[i].Id == 6416)
                {
                    var a = 1;
                }
                Console.WriteLine($"{listProcesses[i].Id:d8} | {listProcesses[i].Handle:d8} | {listProcesses[i].Name.PadRight(50 , ' ')} |");
            }

            Console.ReadLine();
        }
    }
}