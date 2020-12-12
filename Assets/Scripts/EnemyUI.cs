using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUI : MonoBehaviour {
    public float hp;
    private float timer = 0f;
    private bool isDamaged = false;
	// Use this for initialization
	void Start () {
        
	}
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Weapon" && !isDamaged)
        {
            hp -= CharacterControllerScript.dmg;
            isDamaged = true;
        }
    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (isDamaged && timer > 0.3f)
        {
            timer = 0;
            isDamaged = false;
        }
    }
    // Update is called once per frame
    void Update () {
		if (hp <= 0)
        {
            Destroy(gameObject);
        }
	}
}
