using UnityEngine;
using System.Timers;

public class Timer : MonoBehaviour
{
    private System.Timers.Timer timer;

    public int Minutes { get; private set; }
    public int Seconds { get; private set; }

    private const int delta = 1000;
    private const int secsInMin = 60;

    public bool isEnabled { get; set; }

    private void Start()
    {
        SetTimer();
        Restart();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause) Pause();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus) Continue();
    }

    public void Restart()
    {
        ResetTime();
        isEnabled = true;
        if (timer != null)
            timer.Start();
    }

    public void Continue()
    {
        if(timer != null && isEnabled)
            timer.Start();
    }

    public void Pause()
    {
        if (timer != null)
            timer.Stop();
    }

    private void SetTimer()
    {
        timer = new System.Timers.Timer(delta);
        timer.Elapsed += UpdateTimer;
        timer.AutoReset = true;
    }

    private void UpdateTimer(object source, ElapsedEventArgs e)
    {
        Seconds++;
        if(Seconds == secsInMin)
        {
            Seconds = 0;
            Minutes++;
        }
    }

    private void ResetTime()
    {
        Minutes = 0;
        Seconds = 0;
    }
}
