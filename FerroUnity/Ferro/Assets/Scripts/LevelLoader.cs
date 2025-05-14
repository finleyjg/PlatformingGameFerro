using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string nextSceneName = "CaveWorld";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(nextSceneName);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");

        if (player != null && spawnPoint != null)
        {
            player.transform.position = spawnPoint.transform.position;
        }

        SceneManager.sceneLoaded -= OnSceneLoaded; 
    }
}
