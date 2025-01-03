using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource m_AudioSource;


    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // Destroy duplicate
        else if (instance == null && instance == this)
        {
            Destroy(gameObject);
        }
    }
    public void PlaySound(AudioClip audioClip)
    {
        m_AudioSource.PlayOneShot(audioClip);
    }
}
