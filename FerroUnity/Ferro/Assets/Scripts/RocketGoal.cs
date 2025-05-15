using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketGoal : MonoBehaviour
{
    public string creditsSceneName = "Credits";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(creditsSceneName);
        }
    }
}
