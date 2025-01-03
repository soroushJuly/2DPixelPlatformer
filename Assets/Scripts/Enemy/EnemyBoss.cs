using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float attackCooldown;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private BoxCollider2D boxCollider;

    private Animator animator;
    private float cooldownTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cooldownTimer = Mathf.Infinity;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;

        // Attack if you see the enemy
        if (PlayerInsight())
        {

        }
    }

    private bool PlayerInsight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.left, 0, playerLayer);
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(boxCollider.bounds.center, boxCollider.bounds.size);
    }
}
