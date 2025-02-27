using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private AudioClip hurtSound;

    private PlayerRespawn PlayerRespawn;
    private Animator animator;

    public float health { get; private set; }
    public bool isDead { get; private set; }

    private void Awake()
    {
        health = maxHealth;
        // Assuming that the health is always in an object with animator
        animator = GetComponent<Animator>();
        PlayerRespawn = GetComponent<PlayerRespawn>();
    }

    public void TakeDamage(float damage)
    {
        health = Mathf.Clamp(health - damage, 0, maxHealth);

        if (health > 0)
        {
            // player hurt
            SoundManager.instance.PlaySound(hurtSound);
            animator.SetTrigger("hurt");
            // Make Player Invulnerable for a while
            StartCoroutine(Invulnerable());
        }
        else
        {
            // player dies
            Die();
        }
    }

    public void Respawn()
    {
        health = maxHealth;
        animator.ResetTrigger("die");
        GetComponent<PlayerMovement>().enabled = true;
        isDead = false;
    }

    private IEnumerator Invulnerable()
    {
        // layer 10,11 are player and enemy
        Physics2D.IgnoreLayerCollision(10, 11, true);
        // wait for the duration, before exe the next line
        yield return new WaitForSeconds(2);
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }

    public void Die()
    {
        GetComponent<PlayerMovement>().enabled = false;
        //animator.SetBool("grounded");
        animator.SetTrigger("die");
        animator.Play("Idle");
        if (PlayerRespawn != null)
            PlayerRespawn.Respawn();
        isDead = true;
    }
}
