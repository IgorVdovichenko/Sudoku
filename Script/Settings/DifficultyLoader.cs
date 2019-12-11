using UnityEngine;
using UnityEngine.UI;

public class DifficultyLoader : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private SettingsLoader loader;
    [SerializeField]
    private Text text;

    private void Awake()
    {
        gameManager.emtyCellsAmount = loader.Data.difficultyLevel.emptyCellsAmount;
        text.text = loader.Data.difficultyLevel.name;
    }
}
