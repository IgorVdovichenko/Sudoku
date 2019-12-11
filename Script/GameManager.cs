using UnityEngine;
using UnityEngine.Events;
using SudokuPuzzle;

public class GameManager : MonoBehaviour
{
    [Range(0, 50)]
    public int emtyCellsAmount;

    [SerializeField]
    private bool isShuffled = false;

    private IBaseGrid baseGrid = new BaseGrid();
    private ICellRemover cellRemover;
    private Shuffler shuffler;
    private byte[,][,] grid;

    private Game game;

    [SerializeField]
    private Board board;

    [SerializeField]
    private Keyboard keyboard;

    public UnityEvent onComplete;
    public UnityEvent onStartNew;

    private void Start()
    {
        board.onClick.AddListener(keyboard.Activate);
        keyboard.onClick.AddListener(SetCell);
        StartNew();
    }

    public void StartNew()
    {
        grid = baseGrid.Generate();
        shuffler = new Shuffler(grid);
        cellRemover = new CellsRemover(grid);
        bool[,][,] emptyCells = cellRemover.GetEmptyCells(emtyCellsAmount);
        if (isShuffled)
            shuffler.Shuffle();
        game = new Game(grid, emptyCells);
        board.Create(grid, emptyCells);
        onStartNew.Invoke();
    }

    public void ResetBoard()
    {
        board.ResetAll();
        game.ResetAll();
    }

    private void SetCell(byte value)
    {
        CellPosition gridPos = 
            new CellPosition((int)board.ActiveCell.gridPos.x, (int)board.ActiveCell.gridPos.y);
        CellPosition regionPos = 
            new CellPosition((int)board.ActiveCell.regionPos.x, (int)board.ActiveCell.regionPos.y);
        if (value == 0)
        {
            game.ResetCell(gridPos, regionPos);
            board.ResetActiveCell();
        }
        else
        {
            game.SetCell(value, gridPos, regionPos);
            board.SetActiveCell(value);
        }
        if (game.IsSolved())
        {
            Debug.Log("The puzzle is solved!");
            board.IsInteractable(false);
            onComplete.Invoke();
        }
    }
}
