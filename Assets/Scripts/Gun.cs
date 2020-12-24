using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float offset;
    public GameObject bullet;
    public Transform shotPoint;

    private float TimeBtwShots;
    public float startTimeBtwShots;

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, offset + rotZ);

        if (TimeBtwShots <= 0)
        {
            if (Input.GetMouseButton(1))
            {
                Instantiate(bullet, shotPoint.position, transform.rotation);
                TimeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            TimeBtwShots -= Time.deltaTime;
        }
    }
}
