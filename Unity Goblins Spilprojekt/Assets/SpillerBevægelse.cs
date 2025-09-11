using UnityEngine;

public class SpillerBevægelse : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float Speed;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * Speed, body.linearVelocity.y);

        if (Input.GetKey(KeyCode.Space))
        {
            body.linearVelocity = new Vector2(body.velocity.x, Speed);
        }
    }
    
}
