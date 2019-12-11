using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    private Saver<SettingsData> saver;
    [HideInInspector]
    public SettingsData data;

    private void Awake()
    {
        saver = new Saver<SettingsData>();
        data = saver.GetData();
    }

    public void Save()
    {
        saver.SaveData(data);
    }
}
