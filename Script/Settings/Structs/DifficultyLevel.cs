
[System.Serializable]
public struct DifficultyLevel
{
    public string name;
    public int emptyCellsAmount;

    public DifficultyLevel(string name, int emptyCellsAmount)
    {
        this.name = name;
        this.emptyCellsAmount = emptyCellsAmount;
    }
}
