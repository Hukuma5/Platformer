using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    public GameObject bulleteff;

    void Update()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.right, distance, whatIsSolid);
        if (hitinfo.collider != null)
        {
            if ((hitinfo.collider.CompareTag("Enemy")) || (hitinfo.collider.CompareTag("Flying_Enemy")))
            {
                hitinfo.collider.GetComponent<Enemy>().TakeDamage(damage);

            }
            Instantiate(bulleteff, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
