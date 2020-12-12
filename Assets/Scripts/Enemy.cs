using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public int health;
    public float speed;
    public GameObject deatheffect;
    public int dmg;
    private float stopTime;
    public float startstopTime;
    private float normalspeed;
    private CharacterControllerScript player;
    public bool isFacingRight;
    private Rigidbody2D rb;
    //private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<CharacterControllerScript>();
        normalspeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        timeBtwAttack -= Time.deltaTime;
        if (stopTime <= 0)
        {
            speed = normalspeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (isFacingRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        
    }

    public void TakeDamage(int damage)
    {
        stopTime = startstopTime;
        Instantiate(deatheffect, transform.position, Quaternion.identity);
        health -= damage;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (timeBtwAttack <= 0)
            {
                //anim.SetTrigger("Boom");
                OnEnemyAttack();
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            Debug.Log("boom1");
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void OnEnemyAttack()
    {
        Instantiate(deatheffect, player.transform.position, Quaternion.identity);
        player.hp -= dmg;
        timeBtwAttack = startTimeBtwAttack;
    }
}
