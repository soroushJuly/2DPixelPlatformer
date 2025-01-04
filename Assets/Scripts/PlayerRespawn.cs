using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Transform currentCheckpoint;
    private Health playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        currentCheckpoint = transform;
    }
    public void Respawn()
    {
        transform.position = currentCheckpoint.position;
        playerHealth.Respawn();

        Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            currentCheckpoint = collision.transform;
            collision.GetComponent<Collider2D>().enabled = false;
        }
    }
}
