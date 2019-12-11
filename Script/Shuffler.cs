using UnityEngine;
using SudokuPuzzle;

public class Shuffler
{
    private IShuffler shuffler;
    private byte[,][,] grid;
    private int gridHeight;
    private int gridWidth;

    public Shuffler(byte[,][,] grid)
    {
        this.grid = grid;
        shuffler = new SudokuPuzzle.Shuffler(grid);
        gridHeight = grid.GetLength(0);
        gridWidth = grid.GetLength(1);
    }

    public void Shuffle()
    {
        SwapRows(15);
        SwapColumns(15);
        SwapRowsOfRegions(5);
        SwapColumnsOfRegions(5);
    }

    private void SwapRowsOfRegions(int seed)
    {
        int counter = seed;
        while(counter >= 0)
        {
            int row1 = Random.Range(0, gridHeight);
            int row2 = Random.Range(0, gridHeight);
            if (row1 != row2)
            {
                shuffler.SwapAreaRows(row1, row2);
                counter--;
            }
        }
    }

    private void SwapColumnsOfRegions(int seed)
    {
        int counter = seed;
        while (counter >= 0)
        {
            int col1 = Random.Range(0, gridWidth);
            int col2 = Random.Range(0, gridWidth);
            if (col1 != col2)
            {
                shuffler.SwapAreaColumn(col1, col2);
                counter--;
            }
        }
    }

    private void SwapRows(int seed)
    {
        int counter = seed;
        while (counter >= 0)
        {
            int regionRow = Random.Range(0, gridHeight);
            int row1 = Random.Range(0, grid[regionRow, 0].GetLength(0));
            int row2 = Random.Range(0, grid[regionRow, 0].GetLength(0));
            if (row1 != row2)
            {
                shuffler.SwapRowsInArea(regionRow, row1, row2);
                counter--;
            }
        }
    }

    private void SwapColumns(int seed)
    {
        int counter = seed;
        while (counter >= 0)
        {
            int regionCol = Random.Range(0, gridWidth);
            int col1 = Random.Range(0, grid[0, regionCol].GetLength(0));
            int col2 = Random.Range(0, grid[0, regionCol].GetLength(0));
            if (col1 != col2)
            {
                shuffler.SwapColumnsInArea(regionCol, col1, col2);
                counter--;
            }
        }
    }
}
