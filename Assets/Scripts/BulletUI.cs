using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUI : MonoBehaviour {
    private Rigidbody2D rb;
    public float maxSpeed = 5f;
    public GameObject Respawn;
    public GameObject Enemy;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = Respawn.transform.position;
        }
    }
    
    // Update is called once per frame
    void Update () {
        if (rb.position.x < 40)
        {
            rb.transform.position = Enemy.transform.position;
        }
        rb.velocity = new Vector2(-maxSpeed, 0);
    }
}
