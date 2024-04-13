namespace ApplicationCore.Interfaces
{
    public interface ICommand
    {
        void PrintGrid();
        void RevealAll();
        void RevealCell(int x, int y);
    }
}