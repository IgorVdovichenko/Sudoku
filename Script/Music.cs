using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip clip;

    public bool isOn = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
        Play();
    }

    public void Play()
    {
        if (clip == null)
            throw new System.Exception("Audio Clip is null!");
        if (isOn == false)
            return;
        audioSource.Play();
    }

    public void Stop()
    {
        audioSource.Stop();
    }

    public void Pause()
    {
        audioSource.Pause();
    }
}
