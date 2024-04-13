using ApplicationCore.Interfaces;

namespace ApplicationCore.Wrappers
{
    public class ConsoleWrapper : IConsole
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void Write(char message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message = "")
        {
            Console.WriteLine(message);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}