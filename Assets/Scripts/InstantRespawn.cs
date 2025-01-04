using UnityEngine;

public class InstantRespawn : MonoBehaviour
{
    [SerializeField] private Health playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerHealth.Die();
    }

}
