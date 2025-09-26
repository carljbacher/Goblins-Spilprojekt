using UnityEngine;

public class SpillerBevægelse : MonoBehaviour
{
    private Rigidbody2D body; // ???
    [SerializeField] private float Speed; // Styre spillerens movenmentspeed
    [SerializeField] private float jumpPower; // Styre spillerens jumphight
    private BoxCollider2D boxCollider; // ???
    [SerializeField] private LayerMask groundLayer; // Til at spillet ved hvad der er ground
    [SerializeField] private LayerMask wallLayer; // Til at spillet ved hvad der er wall
    private float horizontalInput; // Gør så spilleren kan gå til siden
    [SerializeField] private float wallJumpX; // Regulere hvor meget man bevæger sig på x-aksen når man walljumper
    [SerializeField] private float wallJumpY; // Regulere hvor meget man bevæger sig på y-aksen når man walljumper
    private bool wallJumpCounter; // Gør så man ikke kan lave 2 walljumps i træk
    public GameOverScreen GameOverScreen;
    private bool GameOver;

    private void Awake() // Koden henter ting fra unity
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        outOfBounds();
        
        if (GameOver)
        {
            GameOverScreen.Setup();
        }



        horizontalInput = Input.GetAxis("Horizontal"); // Spillet finder ud af om spilleren kigger mod højre eller venstre
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(0.25f, 0.25f, 1);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-0.25f, 0.25f, 1);


        if (isGrounded()) // Genstarter spillerens walljump
            wallJumpCounter = true;

        //Jump funktion
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        if (Input.GetKeyUp(KeyCode.Space) && body.linearVelocity.y > 0)
            body.linearVelocity = new Vector2(body.linearVelocity.x, body.linearVelocity.y / 2);

        if (onWall() && !isGrounded())
        {
            if (body.linearVelocity.y < -2f) // maks faldhastighed når man glider
            {
                body.linearVelocity = new Vector2(body.linearVelocity.x, -2f);
            }
        }
        else if (onWallSide() && !isGrounded())
        {
            if (body.linearVelocity.y < -2f) // maks faldhastighed når man glider
            {
                body.linearVelocity = new Vector2(body.linearVelocity.x, -2f);
            }            
        }
        else
        {
            body.linearVelocity = new Vector2(horizontalInput * Speed, body.linearVelocity.y);
        }

    }


    private void Jump()
    {
        if (!onWall() && !isGrounded()) return;

        if (onWall() && wallJumpCounter)
        {
            wallJump();
        }
        else
        {
            if (isGrounded())
            {
                body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower);
                Debug.Log("Normal jump test");
            }
        }
    }

    private void wallJump()
    {
        body.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * wallJumpX, wallJumpY);
        wallJumpCounter = false;
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

    private void outOfBounds()
    {
        if (body.transform.position.y < -10)
            GameOver = true;
    }

    private bool onWallSide()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, groundLayer);
        return raycastHit.collider != null;    
    }
    
}
