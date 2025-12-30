using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void Button_Start()
    {
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
}
