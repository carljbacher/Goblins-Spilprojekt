using Unity.Mathematics;
using UnityEngine;
public class walkingcheck : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        animator.SetFloat("VelocityX",math.abs(rb.linearVelocity.x));

    }
}
