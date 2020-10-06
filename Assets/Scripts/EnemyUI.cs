using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUI : MonoBehaviour {
    public float hp;
    public GameObject me;
	// Use this for initialization
	void Start () {
        
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Weapon")
        {
            hp -= CharacterControllerScript.dmg;
        }
    }
    // Update is called once per frame
    void Update () {
		if (hp <= 0)
        {
            me.SetActive(false);
        }
	}
}
