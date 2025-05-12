using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource musicSource;

    public void ToggleMusic(bool isOn)
    {
        if (isOn)
        {
            if (!musicSource.isPlaying)
            {
                musicSource.Play();
            }
        }
        else
        {
            musicSource.Pause();
        }
    }
}
