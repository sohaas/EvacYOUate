using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // TODO: expand with image

    [SerializeField] private TextMeshProUGUI timerDisplay;
    [SerializeField] private bool triggerEvent;
    private int remainingDuration;

    // read only variable
    public int Duration { get; private set; }

    private void Awake()
    {
        ResetTimer();
    }

    private void ResetTimer()
    {
        timerDisplay.text = "00:00";
        Duration = remainingDuration = 0;
    }

    public Timer SetDuration(int seconds)
    {
        Duration = remainingDuration = seconds;
        return this;
    }

    public void Begin()
    {
        StopAllCoroutines();
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration > 0)
        {
            UpdateUI(remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        End();
    }

    private void UpdateUI(int seconds)
    {
        timerDisplay.text = string.Format("{0:D2}:{1:D2}", seconds/60, seconds%60);
    }

    public void End()
    {
        ResetTimer();

        if (triggerEvent)
        {
            EventManager.instance.TimeIsUp();
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
