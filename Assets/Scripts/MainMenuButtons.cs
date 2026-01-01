using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void Button_Start()
    {
        if (GameTimer.Instance != null)
        {
            GameTimer.Instance.ResetTimer();
        }
        if (TimeDisplay.Instance != null)
        {
            TimeDisplay.Instance.RestartTimer();
        }
        SceneManager.LoadScene(2);
    }
    public void Button_Settings()
    {
        SceneManager.LoadScene(1);
    }
    public void Button_Quit()
    {
        Application.Quit();
    }
    public void Button_MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
