using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthbar;
    public Image healtBarEffect;
    float maxhealth;
    public static float health;
    CharacterControllerScript player;
    private float healthspeed = 0.003f;



    void Start()
    {
        player = FindObjectOfType<CharacterControllerScript>();
        healthbar = GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        maxhealth = player.maxhp;
        health = player.hp;
        healthbar.fillAmount = health / maxhealth;
        if (healtBarEffect.fillAmount > healthbar.fillAmount)
        {
            healtBarEffect.fillAmount -= healthspeed;
        }
        else
        {
            healtBarEffect.fillAmount = healthbar.fillAmount;
        }
    }
}
