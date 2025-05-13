using System.Collections;
using UnityEngine;
using TMPro;

public class CoinPile : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public float messageDuration = 2f;
    private bool isCollected = false;
    public float speedIncreaseAmount = 2f;
    private RobotMovement playerMovement;

    void Start()
    {
        playerMovement = FindObjectOfType<RobotMovement>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isCollected && other.CompareTag("Player"))
        {
            isCollected = true;
            StartCoroutine(ShowMessage());
        }
    }

    IEnumerator ShowMessage()
    {
        messageText.text = "Movement Speed Increased";
        messageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(messageDuration);
        messageText.gameObject.SetActive(false);
        gameObject.SetActive(false);
        if (playerMovement != null)
        {
            playerMovement.IncreaseMovementSpeed(speedIncreaseAmount);
        }
    }
}
