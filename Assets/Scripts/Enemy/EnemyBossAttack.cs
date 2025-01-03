using UnityEngine;

public class EnemyBossAttack : MonoBehaviour
{
    [SerializeField] private GameObject boss;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            boss.GetComponent<EnemyBoss>().playerIsInAttackRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boss.GetComponent<EnemyBoss>().playerIsInAttackRange = false;
        }
    }
}
