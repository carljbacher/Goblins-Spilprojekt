using UnityEngine;

public class SpillerBevægelse : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float Speed;
    [SerializeField] private float jumpPower;
    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private float wallJumpCooldown;
    private float horizontalInput;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");

        // if (horizontalInput > 0.01f)
        //    transform.localScale = Vector3.one;
        //else if (horizontalInput < -0.01f)
        //    transform.localScale = new Vector3(-1, 1, 1);


        // Wall jump logik
            if (wallJumpCooldown > 0.2f)
            {


                body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * Speed, body.linearVelocity.y);

                if (onWall() && !isGrounded())
                {
                    body.gravityScale = 0;
                    body.linearVelocity = Vector2.zero;
                }
                else // Skal ændres hvis tyngdekraften bliver ændret
                {
                    body.gravityScale = 4;
                }

                if (Input.GetKey(KeyCode.Space))
                {
                    Jump();
                }

            }
            else
            {
                wallJumpCooldown += Time.deltaTime;
            }
    }

    private void Jump()
    {
        if (isGrounded())
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower);
        }

        else if (onWall() && !isGrounded())
        {
            if (horizontalInput == 0)
            {
                body.linearVelocity = new Vector2(Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                body.linearVelocity = new Vector2(Mathf.Sign(transform.localScale.x) * 3, 10);
            }
            wallJumpCooldown = 0;
            
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }


    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

        private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
}
