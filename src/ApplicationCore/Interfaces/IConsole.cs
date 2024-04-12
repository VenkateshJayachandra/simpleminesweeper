namespace ApplicationCore.Interfaces
{
    public interface IConsole
    {
        void Write(char message);
        void Write(string message);
        void WriteLine(string message = "");
        void Clear();
        string ReadLine();
    }
}