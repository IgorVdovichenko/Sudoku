using UnityEngine;
using System.Collections.Generic;

public class Board : MonoBehaviour
{
    [SerializeField]
    private GameObject cellPrefab;

    private List<GameObject> cells = new List<GameObject>();
    private List<SelectableCell> selectableCells = new List<SelectableCell>();

    [HideInInspector]
    public BoolEvent onClick;

    public SelectableCell ActiveCell { get; private set; }

    public void Create(byte[,][,] array, bool[,][,] emptyCells)
    {
        DeleteAllCells();
        selectableCells.Clear();
        DeselectActiveCell();
        CreateNewGrid(array, emptyCells);
    }

    private void CreateNewGrid(byte[,][,] array, bool[,][,] emptyCells)
    {
        int height = array.GetLength(0);
        int width = array.GetLength(1);
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Vector2 position = new Vector2(i * height, j * width);
                CreateRegion(array[i, j], emptyCells[i, j], position);
            }
        }
    }

    public void SetActiveCell(byte value)
    {
        ActiveCell.gameObject.GetComponent<Cell>().SetText(value);
        DeselectActiveCell();
    }

    public void ResetActiveCell()
    {
        ActiveCell.gameObject.GetComponent<Cell>().HideText();
        DeselectActiveCell();
    }

    public void ResetAll()
    {
        foreach (var cell in selectableCells)
            cell.GetComponent<Cell>().HideText();
        DeselectActiveCell();
    }

    public void IsInteractable(bool value)
    {
        foreach (var cell in selectableCells)
            cell.IsInteractable = value;
    }

    private void DeselectActiveCell()
    {
        if (ActiveCell != null)
        {
            ActiveCell.Select(false);
            Click(ActiveCell);
        }
    }

    private void CreateRegion(byte[,] region, bool[,] emptyCells, Vector2 pos)
    {
        int height = region.GetLength(0);
        int width = region.GetLength(1);
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Vector3 position = new Vector3(j + pos.y, i + pos.x, 0);
                GameObject cellObj = Instantiate(cellPrefab, position, Quaternion.identity, transform);
                Cell cell = cellObj.GetComponent<Cell>();
                SelectableCell selCell = cellObj.GetComponent<SelectableCell>();
                selCell.onClick.AddListener(Click);
                SetSelectableCellCoords(selCell, new Vector2(pos.x/width, pos.y/height), new Vector2(i, j));
                cells.Add(cellObj);
                if (emptyCells[i, j] == false)
                {
                    cell.SetText(region[i, j]);
                    selCell.enabled = false;
                }
                else
                {
                    cell.SetTextColor(selCell.textColor);
                    cell.HideText();
                    selectableCells.Add(selCell);
                }
            }
        }
    }

    private void SetSelectableCellCoords(SelectableCell cell, Vector2 gridPos, Vector2 regionPos)
    {
        cell.gridPos = gridPos;
        cell.regionPos = regionPos;
    }

    private void Click(SelectableCell cell)
    {
        DeselectAllExcept(cell);
        bool hasActiveCell = IsActive();
        onClick.Invoke(hasActiveCell);
        if (hasActiveCell)
            ActiveCell = cell;
        else
            ActiveCell = null;
    }

    private void DeselectAllExcept(SelectableCell cell)
    {
        foreach (var item in selectableCells)
            if (item != cell)
                item.Select(false);
    }

    private bool IsActive()
    {
        foreach (var item in selectableCells)
            if (item.IsSelected == true)
                return true;
        return false;
    }

    private void DeleteAllCells()
    {
        for (int i = 0; i < cells.Count; i++)
            Destroy(cells[i]);
        cells.Clear();
    }
}
