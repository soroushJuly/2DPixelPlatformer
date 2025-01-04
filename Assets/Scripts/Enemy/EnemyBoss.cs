using System.Collections;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float maxHealth;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float movementSpeed;
    [SerializeField] private AudioClip scytheSwing;
    [SerializeField] private GameObject player;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private GameObject healthBar;


    private float health;
    public bool isDead { get; private set; }
    public bool isActive;
    private Animator animator;
    private float cooldownTimer;
    public bool playerIsInAttackRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerIsInAttackRange = false;
        isActive = false;
        cooldownTimer = Mathf.Infinity;
        animator = GetComponent<Animator>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) { return; }
        cooldownTimer += Time.deltaTime;

        if (isDead) { return; }
        float playerDistance = PlayerDistance();
        float playerDistanceX = GetPlayerDistanceX();


        // In attack range
        if (playerIsInAttackRange && cooldownTimer > attackCooldown)
        {
            SoundManager.instance.PlaySound(scytheSwing);
            animator.SetBool("moving", false);
            animator.SetTrigger("attack");
            cooldownTimer = 0;
        }
        // Enemy far, Get closer to the enemy
        else if (!playerIsInAttackRange && Mathf.Abs(playerDistanceX) > 0.1f)
        {
            // move on the player direction
            if (playerDistanceX <= 0)
            {
                if (transform.localScale.x < 0)
                    FlipSprite();
                // to prevent getting close too much
                if (Mathf.Abs(playerDistanceX) > boxCollider.bounds.size.x / 3)
                    transform.position = new Vector3(transform.position.x - movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                if (transform.localScale.x > 0)
                    FlipSprite();
                if (Mathf.Abs(playerDistanceX) > boxCollider.bounds.size.x / 3)
                    transform.position = new Vector3(transform.position.x + movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            animator.SetBool("moving", true);
        }
        // Enemy far and higher ground, teleport to higher platform!
        //else if (!playerIsInAttackRange && Mathf.Abs(playerDistanceX) < 0.1f)
        //{
        //    // teleport to the platform
        //    animator.SetBool("moving", false);
        //    //StartCoroutine(Teleport());

        //}
    }

    private IEnumerator Teleport()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        gameObject.SetActive(true);
        transform.position = new Vector3(transform.position.x,
               player.GetComponent<BoxCollider2D>().bounds.center.y - player.GetComponent<BoxCollider2D>().bounds.size.y / 2, transform.position.z);
    }

    private float PlayerDistance()
    {
        return Vector3.Distance(player.transform.position, boxCollider.transform.position);
    }

    private float GetPlayerDistanceX()
    {
        return (player.transform.position.x - transform.position.x);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(boxCollider.bounds.center, boxCollider.bounds.size);
    }

    public void CheckHit()
    {
        if (playerIsInAttackRange)
        {
            player.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private void FlipSprite()
    {
        transform.localScale = new Vector3(-1 * transform.localScale.x, 1 * transform.localScale.y, 1 * transform.localScale.z);
    }

    public void TakeDamage(float damage)
    {
        health = Mathf.Clamp(health - damage, 0, maxHealth);

        if (health > 0)
        {
            animator.SetBool("moving", false);
            animator.SetTrigger("hurt");
            // Make Player Invulnerable for a while
            StartCoroutine(Invulnerable());
        }
        else
        {
            animator.SetTrigger("die");
            isDead = true;
        }
        healthBar.transform.localScale = new Vector3(health / maxHealth * healthBar.transform.localScale.x, healthBar.transform.localScale.y, 1);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        isActive = false;
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        isActive = true;
    }

    private IEnumerator Invulnerable()
    {
        // layer 10,11 are player and enemy
        Physics2D.IgnoreLayerCollision(11, 10, true);
        // wait for the duration, before exe the next line
        yield return new WaitForSeconds(1.1f);
        Physics2D.IgnoreLayerCollision(11, 10, false);
    }
}
