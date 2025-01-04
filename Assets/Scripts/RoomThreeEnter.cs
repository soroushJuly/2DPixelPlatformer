using UnityEngine;

public class RoomThreeEnter : MonoBehaviour
{
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AudioClip RoomMusic;
    [SerializeField] private GameObject boss;


    private AudioClip prevAudioClip;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            PlayMusic();
        }

        boss.SetActive(true);
        boss.GetComponent<EnemyBoss>().isActive = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (AudioSource != null)
        {
            AudioSource.clip = prevAudioClip;
            AudioSource.Play();
        }
    }
    public void PlayMusic()
    {
        prevAudioClip = AudioSource.clip;
        if (AudioSource != null)
        {
            AudioSource.clip = RoomMusic;
            AudioSource.Play();
        }
    }
}
