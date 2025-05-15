using System.Collections;
using UnityEngine;
using TMPro;

public class DoubleJumpUnlocker : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public float messageDuration = 3f;
    private bool isCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isCollected && other.CompareTag("Player"))
        {
            isCollected = true;
            RobotMovement movement = other.GetComponent<RobotMovement>();
            if (movement != null)
            {
                movement.canDoubleJump = true;
            }
            StartCoroutine(ShowMessage());
        }
    }

    IEnumerator ShowMessage()
    {
        messageText.text = "Double Jump Functionality: Restored";
        messageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(messageDuration);
        messageText.gameObject.SetActive(false);
        gameObject.SetActive(false);  
    }
}
