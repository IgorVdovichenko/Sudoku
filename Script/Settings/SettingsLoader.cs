using UnityEngine;

public class SettingsLoader : MonoBehaviour
{
    private Saver<SettingsData> loader;

    public SettingsData Data { get; private set; }

    private void Awake()
    {
        loader = new Saver<SettingsData>();
        Data = loader.GetData();
    }
}
