using UnityEngine;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField]
    private DifficultySetup setup;

    [SerializeField]
    private Dropdown selector;

    [SerializeField]
    private SettingsManager settingsManager;

    private void Awake()
    {
        selector.options.Clear();
        SetOptions();
        selector.onValueChanged.AddListener(SetCurrLevel);
        SetCurrLevel(setup.levels.IndexOf(settingsManager.data.difficultyLevel));
    }

    private void SetOptions()
    {
        foreach (var item in setup.levels)
            selector.options.Add(new Dropdown.OptionData(item.name));
    }

    private void SetCurrLevel(int value)
    {
        if(value >= 0)
            settingsManager.data.difficultyLevel = setup.levels[value];
        else
            settingsManager.data.difficultyLevel = setup.levels[0];
        selector.value = value;
    }
}
