using UnityEngine;

public class RoomThreeEnter : MonoBehaviour
{
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AudioClip RoomMusic;


    private AudioClip prevAudioClip;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            prevAudioClip = AudioSource.clip;
            if (AudioSource != null)
            {
                AudioSource.clip = RoomMusic;
                AudioSource.Play();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (AudioSource != null)
        {
            AudioSource.clip = prevAudioClip;
            AudioSource.Play();
        }
    }
}
