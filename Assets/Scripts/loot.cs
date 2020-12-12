using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loot : MonoBehaviour
{
    public GameObject me;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && Input.GetKey(KeyCode.LeftShift))
        {
            CharacterControllerScript.fly = true;    //PC
            //CCSAndroid.fly = true;                   //Android
            me.SetActive(false);
        }
    }
}