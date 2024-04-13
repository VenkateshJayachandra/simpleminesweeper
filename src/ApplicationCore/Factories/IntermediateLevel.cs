using ApplicationCore.Base;

namespace ApplicationCore.Factories
{
    public class IntermediateLevel : GameLevel
    {
        public override int Rows { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int Columns { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int Mines { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        // Intermediate grid field behavior and properties
        public override int[,] GenerateFieldWithMines()
        {
            throw new NotImplementedException();
        }

        public override char[,] GenerateUserGridDisplay()
        {
            throw new NotImplementedException();
        }
    }
}