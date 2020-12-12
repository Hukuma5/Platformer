using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CCSAndroid : MonoBehaviour
{
    public float maxSpeed = 5f;
    private bool isFacingRight = true;
    private Animator anim;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    public Transform groundCheck;
    private float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public static bool fly = false;
    public static float dmg = 1f;
    private int count = 0;
    public GameObject DmgZone;
    private float hittime = 0f;
    private float timer = 0f;
    public static string previousScene;
    public static string curentScene;
    private int directionInput;



    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        if (previousScene == "Shop" && curentScene == "main")
        {
            rb.transform.position = new Vector3(9.91f, 1.78f, -1f);
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", isGrounded);
        anim.SetFloat("vSpeed", rb.velocity.y);
        anim.SetBool("Shoot", false);
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        rb.velocity = new Vector2(maxSpeed * directionInput, rb.velocity.y);
        if (rb.velocity.x > 0 && !isFacingRight)
            Flip();
        else if (rb.velocity.x < 0 && isFacingRight)
            Flip();
        hittime += Time.deltaTime;
        timer += Time.deltaTime;

    }
    private void Update()
    {
        if (DmgZone.active && timer > 0.2f)
        {
            DmgZone.SetActive(false);
            hittime = 0f;
        }
    }
    
    public void Boom(bool isBoom)
    {
        if (timer > 0.43f)
        {
            DmgZone.SetActive(true);
            anim.Play("Boom");
            timer = 0f;
        }
    }

    public void Move(int InputAxis)
    {

        directionInput = InputAxis;

    }
    
    public void Jump(bool isJump)
    {
        
        if (isGrounded)
        {
            anim.SetBool("Ground", false);
            rb.AddForce(new Vector2(0, 62));
        }
        else if (!isGrounded && count == 1)
        {
            anim.SetBool("Ground", false);
            rb.velocity = new Vector2(directionInput * maxSpeed, 0);
            rb.AddForce(new Vector2(0, 62));
            count -= 1;
        }
        if (isGrounded)
        {
            count = 1;
        }
        if ((rb.velocity.y < 0) && fly == true)
        {
            rb.gravityScale = 0.25f;
            if (rb.velocity.y < -3)
            {
                rb.gravityScale = 0f;
                rb.velocity = new Vector2(rb.velocity.x, -3);
            }
        }
        else
        {
            rb.gravityScale = 1f;
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