using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MusicSwitcher : MonoBehaviour
{
    [SerializeField]
    private SettingsManager settingsManager;

    [SerializeField]
    private Dropdown dropdown;

    [SerializeField]
    private List<SwitchOption> options;

    private void Start()
    {
        dropdown.options.Clear();
        InitilizeDropdown();
        dropdown.onValueChanged.AddListener(SetValue);
        SetValue(options.FindIndex(option => option.value == settingsManager.data.musicStatus));
    }

    private void SetValue(int value)
    {
        settingsManager.data.musicStatus = options[value].value;
        dropdown.value = value;
    }

    private void InitilizeDropdown()
    {
        foreach (var item in options)
            dropdown.options.Add(new Dropdown.OptionData(item.label));
    }
}
