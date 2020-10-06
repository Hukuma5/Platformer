using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//test
public class CharacterControllerScript : MonoBehaviour {
    public float maxSpeed = 5f;
    private bool isFacingRight = true;
    private Animator anim;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    public Transform groundCheck;
    private float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public static float dmg = 1f;
    public Transform SwordStart;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", isGrounded);
        anim.SetFloat("vSpeed", rb.velocity.y);
        //if (!isGrounded)
        //    return;
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));
        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
        if (move > 0 && !isFacingRight)
            Flip();
        else if (move < 0 && isFacingRight)
            Flip();
        SwordStart.transform.Rotate(0, 0, -10);
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Mouse0))
       // {
       //     SwordStart
        //}
        
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            rb.AddForce(new Vector2(0, 62));
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
