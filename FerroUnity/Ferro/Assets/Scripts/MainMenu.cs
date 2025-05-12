using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GreenWorld");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exiting Game...");
    }
}
