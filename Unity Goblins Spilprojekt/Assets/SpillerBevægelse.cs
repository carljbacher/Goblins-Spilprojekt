using UnityEngine;

public class SpillerBevægelse : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float Speed;
    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * Speed, body.linearVelocity.y);

        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            Jump();
        }
    }

    private void Jump()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, Speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }


    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
