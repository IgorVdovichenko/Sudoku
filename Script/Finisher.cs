using UnityEngine;

public class Finisher: MonoBehaviour
{
    [SerializeField]
    private AudioSource audio;
    [SerializeField]
    private AudioClip clip;
    
    public void CompletePuzzle()
    {
        audio.PlayOneShot(clip);
    }
}
