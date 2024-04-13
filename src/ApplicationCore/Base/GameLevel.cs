namespace ApplicationCore.Base
{
    public abstract class GameLevel
    {
        public virtual int[,] Grid { get; set; }
        public virtual char[,] DisplayGrid { get; set; }

        protected readonly Random rand = new();

        public abstract int Rows { get; set; }
        public abstract int Columns { get; set; }
        public abstract int Mines { get; set; }

        // Common methods for all the levels 
        public abstract int[,] GenerateFieldWithMines();
        public abstract char[,] GenerateUserGridDisplay();
    }
}