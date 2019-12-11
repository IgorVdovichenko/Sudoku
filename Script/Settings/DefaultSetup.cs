using UnityEngine;

public class DefaultSetup : MonoBehaviour
{
    private Saver<SettingsData> saver;

    [SerializeField]
    private SettingsData settingsData;

    [SerializeField]
    private DifficultySetup difficultySetup;

    private void Awake()
    {
        saver = new Saver<SettingsData>();
        if (saver.FileExists() == false)
        {
            settingsData.difficultyLevel = difficultySetup.levels[0];
            saver.SaveData(settingsData); 
        }
    }
}
