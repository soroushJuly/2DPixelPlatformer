using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator animator;
    private BoxCollider2D boxCollider;

    private bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector3(horizontalInput * speed, body.linearVelocity.y);

        // Flip on Left/Right movement
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.Space) && IsGrounded())
            Jump();

        // Set run parameter true if body has movement
        animator.SetBool("run", horizontalInput != 0);
        animator.SetBool("grounded", IsGrounded());
        animator.SetBool("ascend", body.linearVelocity.y > 0.01f);
        animator.SetBool("descend", body.linearVelocity.y < -0.01f);
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Jump()
    {
        body.linearVelocity = new Vector3(body.linearVelocity.x, speed);
    }

    private bool IsGrounded()
    {
        // Projects a box downwards
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return hit.collider != null;
    }
    private bool IsWall()
    {
        // Projects a box towards the front of the object
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return hit.collider != null;
    }
    public bool canAttack()
    {
        return IsGrounded() && !IsWall();
    }
}
