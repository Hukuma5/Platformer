using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControllerScript : MonoBehaviour {
    public Text moneycount;
    public float maxSpeed = 5f;
    private bool isFacingRight = true;
    private Animator anim;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    public Transform groundCheck;
    private float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public static bool fly = false;
    public int dmg = 1;
    private int count = 1;
    private float move = 0f;
    //public GameObject DmgZone;
    private float hittime = 0f;
    private float timer = 0f;
    public static string previousScene;
    public static string curentScene;
    private bool dash = false;
    private int count_dash = 1;
    private int dashTime = 0;
    private float starttimefordash;
    public int hp;
    public int maxhp = 10;
    private bool flag = true;
    private bool stunLock = false;
    private float stunLocktimer = 0f;
    public VectorValue pos;
    public int coins;
    private Vector3 lastpos;
    public GameObject deatheffect;
    private Enemy[] isAnyoneHere;
    public float timefordash;
    public GameObject hubscene;
    public GameObject HPBuffeff;
    public GameObject DMGBuffeff;
    private void Start()
    {
        Time.timeScale = 1;
        LoadCharacter();
        starttimefordash = timefordash;
        hp = maxhp;
        transform.position = pos.InitialValue;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        if (previousScene == "Shop" && curentScene == "main")
        {
            rb.transform.position = new Vector3(9.91f, 1.78f, -1f);
        }
        
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", isGrounded);
        anim.SetFloat("vSpeed", rb.velocity.y);
        //if (!isGrounded)
        //    return;

        if (!dash)
        {
           
            anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
            
            if (rb.velocity.x > 0 && !isFacingRight)
                Flip();
            else if (rb.velocity.x < 0 && isFacingRight)
                Flip();
        } else dashTime -= 1;
        hittime += Time.deltaTime;
        timer += Time.deltaTime;
        stunLocktimer += Time.deltaTime;
        if (stunLock == true && stunLocktimer > 0.4f)
        {
            stunLock = false;
            
        }
    }

    private void Update()
    {
        if (hp <= 0)
        {
            SaveLoad.AutoSaveGame(this);
            hubscene.SetActive(true);
        }
        if (isGrounded)
        {
            lastpos = transform.position;
        }
        moneycount.text = coins.ToString();
        
        if (!stunLock)
        {
            if (!dash)
            {
                move = Input.GetAxis("Horizontal");
                if (move != 0)
                {
                    flag = false;
                    rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(0, rb.velocity.y);
                }
                if (move == 0 && flag == false)
                {
                    rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
                    flag = true;
                }
            }
            if (dash)
            {
                if (dashTime == 0)
                {
                    dash = false;
                    rb.velocity = new Vector2(0, 0);
                    rb.gravityScale = 1.5f;
                }
                else
                {
                    return;
                }
            }
            starttimefordash -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.LeftShift) && count_dash == 1 && starttimefordash <= 0)
            {
                starttimefordash = timefordash;
                if (isFacingRight)
                {
                    rb.gravityScale = 0f;
                    rb.velocity = new Vector2(20, 0);
                    dash = true;
                    dashTime = 10;
                    count_dash = 0;
                }
                else
                {
                    rb.gravityScale = 0f;
                    rb.velocity = new Vector2(-20, 0);
                    dash = true;
                    dashTime = 10;
                    count_dash = 0;
                }
            }
            //if (Input.GetKeyDown(KeyCode.Mouse0))
            //{
            //    if (timer > 0.43f)
            //    {
            //        DmgZone.SetActive(true);
            //        anim.Play("Boom");
            //        timer = 0f;
            //    }
            //}
            //if (DmgZone.active && timer > 0.2f)
            //{
            //    DmgZone.SetActive(false);
            //    hittime = 0f;
            //}
            if (isGrounded)
            {
                count = 1;
                count_dash = 1;
            }
            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("Ground", false);
                rb.AddForce(new Vector2(0, 75));
            }
            else if (!isGrounded && Input.GetKeyDown(KeyCode.Space) && count == 1)
            {
                anim.SetBool("Ground", false);
                rb.velocity = new Vector2(move * maxSpeed, 0);
                rb.AddForce(new Vector2(0, 75));
                count -= 1;
            }
            if ((rb.velocity.y < 0) && Input.GetKey(KeyCode.Space) && fly == true)
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
                rb.gravityScale = 1.5f;
            }
        }
    }

    ////void OnCollisionEnter2D(Collision2D collision)
    ////{
    ////    if (gameObject.tag == "Player")
    ////    {
    ////        Debug.Log(collision.collider.name);
    ////        if (collision.collider.tag == "Opponent")
    ////        {
    ////            hp -= 2;

    ////            if (hp <= 0)
    ////            {
    ////                Destroy(gameObject);
    ////            }
    ////            else
    ////            {
    ////                stunLock = true;
    ////                stunLocktimer = 0;
    ////                Transform opponent = collision.transform;
    ////                //Vector2 jjump = new Vector2(-10, 30);
    ////                // rb.AddForce(jjump);
    ////                if (opponent.position.x < rb.position.x)
    ////                    rb.velocity = new Vector2(10, 10);
    ////                else rb.velocity = new Vector2(-10, 10);
    ////            }

    ////        }
    ////    }
    ////}


private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public void AutoLoadCharacter()
    {
        if (curentScene == "1")
        {
            hubscene.SetActive(true);
        }
        SaveData data = SaveLoad.AutoLoadGame();
        if (!data.Equals(null))
        {
            maxhp = data.HP;
            //hp = data.currHP;
            coins = data.money;
            dmg = data.DMG;
            transform.position = new Vector3(0f, 0f, 0f);
            stunLocktimer = 0f;
            stunLock = true;
        }
    }
    public void LoadCharacter()
    {
        SaveData data = SaveLoad.AutoLoadGame();
        if (!data.Equals(null))
        {
            maxhp = data.HP;
          //hp = data.currHP;
            coins = data.money;
            dmg = data.DMG;
            transform.position = new Vector3(0f, 0f, 0f);
            stunLocktimer = 0f;
            stunLock = true;
        }
    }

    public void BuyHpBuff()
    {
        
        CharacterControllerScript player = FindObjectOfType<CharacterControllerScript>();
        Instantiate(HPBuffeff, player.transform.position, Quaternion.identity);
        player.coins -= 100;
        player.maxhp += 1;      
        SaveLoad.AutoSaveGame(player);
    }

    public void BuyDmgBuff()
    {
        CharacterControllerScript player = FindObjectOfType<CharacterControllerScript>();
        Instantiate(DMGBuffeff, player.transform.position, Quaternion.identity);
        player.coins -= 100;
        player.dmg += 1;
        SaveLoad.AutoSaveGame(player);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
            coins += 1;
        }
        else if (collision.tag == "Big_Coin")
        {
            Destroy(collision.gameObject);
            coins += 5;
        }
        if (collision.tag == "Spike")
        {
            hp -= 10;
            rb.velocity = new Vector2(0f, 0f);
            stunLocktimer = 0f;
            stunLock = true;
            Instantiate(deatheffect, transform.position, Quaternion.identity);
            transform.position = lastpos;
        }
    }
}


