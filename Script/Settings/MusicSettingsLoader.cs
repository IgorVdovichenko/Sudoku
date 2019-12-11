using UnityEngine;

public class MusicSettingsLoader : MonoBehaviour
{
    [SerializeField]
    private SettingsLoader loader;

    [SerializeField]
    private Music music;

    private void Awake()
    {
        music.isOn = loader.Data.musicStatus;
    }
}
