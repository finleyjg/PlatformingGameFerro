using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f; 
    }

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
