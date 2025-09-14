using UnityEngine;

public class SpillerBevægelse : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float Speed;
    [SerializeField] private float jumpPower;
    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private float horizontalInput;
    [SerializeField] private float coyoteTime;
    private float coyoteCounter;
    [SerializeField] private float wallJumpX;
    [SerializeField] private float wallJumpY;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(0.15f, 0.25f, 1);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-0.15f, 0.25f, 1);

        //Jump funktion
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        if (Input.GetKeyUp(KeyCode.Space) && body.linearVelocity.y > 0)
            body.linearVelocity = new Vector2(body.linearVelocity.x, body.linearVelocity.y / 2);

        if (onWall())
        {
            body.gravityScale = 0;
            body.linearVelocity = Vector2.zero;
        }
        else
        {
            body.gravityScale = 4;
            body.linearVelocity = new Vector2(horizontalInput * Speed, body.linearVelocity.y);

            if (isGrounded())
            {
                coyoteCounter = coyoteTime;
            }
            else
                coyoteCounter -= Time.deltaTime;
        }
    }


    private void Jump()
    {
        if (coyoteCounter < 0 && !onWall()) return;

        if (onWall())
            wallJump();
        else
        {
            if (isGrounded())
                body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower);
            else
            {
                if (coyoteCounter > 0)
                    Debug.Log("coyoteTest");
                    body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower);
            }
            coyoteCounter = 0;
        }
    }

    private void wallJump()
    {
        body.AddForce(new Vector2(-Mathf.Sign(transform.localScale.x) * wallJumpX, wallJumpY));
        Debug.Log("TEST_wallJump");
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
