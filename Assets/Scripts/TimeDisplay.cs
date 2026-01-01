using UnityEngine;
using TMPro;

public class TimeDisplay : MonoBehaviour
{
    public TMP_Text timeText;
    private bool stopTimer = false;
    private float elapsedTime;
    public static TimeDisplay Instance;
 private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: keep across scenes
        }
        else
        {
            Destroy(gameObject); // Ensure only one exists
        }
    }
    void Update()
    {
        if (!stopTimer)
        {
            elapsedTime = GameTimer.Instance.elapsedTime;
        }

        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        if (!stopTimer)
        {
            timeText.text = $"Time: {minutes:D2}:{seconds:D2}";
        }
        if (stopTimer)
        {
            timeText.text = "";
        }
    }

    // Call this when the game ends
    public void StopTimer()
    {
        stopTimer = true;
    }
    public void RestartTimer()
    {
        stopTimer = false;
    }
}

