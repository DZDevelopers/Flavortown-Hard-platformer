using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance;

    [HideInInspector]
    public float elapsedTime;    // Total time played
    private float lastUpdateTime;

    private bool isRunning = true; // Controls if timer is counting

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            lastUpdateTime = Time.time;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.time - lastUpdateTime;
        }
        lastUpdateTime = Time.time;
    }

    // Call this when the game is finished (credits)
    public void StopTimer()
    {
        isRunning = false;
    }

    // Call this when starting a new game
    public void ResetTimer()
    {
        elapsedTime = 0f;
        lastUpdateTime = Time.time;
        isRunning = true;
    }
}
