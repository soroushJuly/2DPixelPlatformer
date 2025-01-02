using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private Animator animator;
    public float health { get; private set; }

    private void Awake()
    {
        health = maxHealth;
        // Assuming that the health is always in an object with animator
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        health = Mathf.Clamp(health - damage, 0, maxHealth);

        if (health > 0)
        {
            // player hurt
            animator.SetTrigger("hurt");
            // Make Player Invulnerable for a while
            StartCoroutine(Invulnerable());
        }
        else
        {
            // player dies
            animator.SetTrigger("die");
            GetComponent<PlayerMovement>().enabled = false;
        }
    }

    private IEnumerator Invulnerable()
    {
        // layer 10,11 are player and enemy
        Physics2D.IgnoreLayerCollision(10,11, true);
        // wait for the duration, before exe the next line
        yield return new WaitForSeconds(2);
        Physics2D.IgnoreLayerCollision(10,11, false);
    }
}
