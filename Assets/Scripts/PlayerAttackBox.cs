using UnityEngine;

public class PlayerAttackBox : MonoBehaviour
{
    [SerializeField] private PlayerAttack PlayerAttack;

    private void Awake()
    {
        //PlayerAttack = GetComponentInParent<PlayerAttack>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            PlayerAttack.AddCollision(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            PlayerAttack.RemoveCollision(collision);
    }
}
