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
    private bool PlayerInRange;
    public float visionrange;
    public LayerMask PlayerLayer;
    public GameObject coin;
    public GameObject big_coin;
    private GameObject copy;
    public int coin_count;
    public int big_coin_count;
    //private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        if (tag == "Enemy")
        {
            rb = GetComponent<Rigidbody2D>();
        }        
        player = FindObjectOfType<CharacterControllerScript>();
        normalspeed = speed;
        

    }
    // Update is called once per frame
    void Update()
    {
        var rnd = new System.Random();
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
            var p = transform.position;
            int val = 0;
            for (int i = 0; i < coin_count; i++)
            {
                val = rnd.Next(0, 25);
                copy = Instantiate(coin, new Vector3(p.x, p.y, p.z), Quaternion.identity);
                copy.GetComponent<Rigidbody2D>().AddForce(new Vector2(val, val));
                Debug.Log("pew");
                Debug.Log(val);
            }
            for (int i = 0; i < big_coin_count; i++)
            {
                val = rnd.Next(0, 25);
                copy = Instantiate(big_coin, new Vector3(p.x, p.y, p.z), Quaternion.identity);
                copy.GetComponent<Rigidbody2D>().AddForce(new Vector2(val, val));
            }
            Destroy(gameObject);
        }
        PlayerInRange = Physics2D.OverlapCircle(transform.position, visionrange, PlayerLayer);
        if (tag == "Enemy")
        {
            if (isFacingRight)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }
        else
        {
            if (tag == "Flying_Enemy")
            {
                if (PlayerInRange)
                {
                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                }
                
            }
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

    public void Flip()
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

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, visionrange);
    }
}
