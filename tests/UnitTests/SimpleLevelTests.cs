using ApplicationCore.Services;

public class SimpleLevelTests
{
    [Fact]
    public void GenerateFieldWithMines_CreatesCorrectNumberOfMines()
    {
        var level = new BeginnerLevel();

        var field = level.GenerateFieldWithMines();

        int mineCount = 0;
        for (int i = 0; i < level.Rows; i++)
        {
            for (int j = 0; j < level.Columns; j++)
            {
                if (field[i, j] == -1)
                {
                    mineCount++;
                }
            }
        }

        Assert.Equal(level.Mines, mineCount);
    }
}