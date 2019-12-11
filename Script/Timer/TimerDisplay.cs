using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField]
    private Timer timer;

    [SerializeField]
    private Text minutesText;

    [SerializeField]
    private Text secondsText;

    private void Update()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        minutesText.text = timer.Minutes.ToString("00");
        secondsText.text = timer.Seconds.ToString("00");
    }
}
