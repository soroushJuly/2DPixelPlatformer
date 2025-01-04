using UnityEngine;

public class EnemySideways : MonoBehaviour
{
    [SerializeField] private float damage;
    // How far the enemy will move
    [SerializeField] private float distance;
    [SerializeField] private float speed;

    [SerializeField] private bool isMovingLeft;
    private Vector3 direction;

    private Vector3 initialPosition;

    private void Start()
    {
        if (!isMovingLeft)
            FlipSprite();
        initialPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<Health>().TakeDamage(damage);
    }

    private void Update()
    {
        if (!enabled) return;
        if (isMovingLeft)
        {
            if (transform.position.x < initialPosition.x - distance)
            {
                isMovingLeft = false;
                // TODO: there should be a better way to do this?
                FlipSprite();

            }
            else
                transform.position += speed * Time.deltaTime * Vector3.left;
        }
        else
        {
            if (transform.position.x > initialPosition.x + distance)
            {

                isMovingLeft = true;
                FlipSprite();
            }
            else
                transform.position += speed * Time.deltaTime * Vector3.right;
        }
    }

    private void FlipSprite()
    {
        transform.localScale = new Vector3(-1 * transform.localScale.x, 1 * transform.localScale.y, 1 * transform.localScale.z);
    }
}
