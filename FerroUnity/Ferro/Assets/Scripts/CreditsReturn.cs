using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsReturn : MonoBehaviour
{
    public string menuSceneName = "Menu";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReturnToMenu();
        }
    }

    void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuSceneName);
    }
}
