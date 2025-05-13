using UnityEngine;

public class GyroJumpSound : MonoBehaviour
{
    public AudioSource jumpSource;

    public void PlayJumpSound()
    {
        if (!jumpSource.isPlaying)
        {
            jumpSource.Play();
        }
    }
}
