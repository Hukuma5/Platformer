using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    //public int currHP;
    public int HP;
    public int money;
    public float[] position;
    public int DMG;

    public SaveData(CharacterControllerScript character)
    {

        HP = character.maxhp;
        //currHP = character.hp;
        money = character.coins;
        DMG = character.dmg;

        position = new float[3]
        {
            character.transform.position.x,
            character.transform.position.y,
            character.transform.position.z
        };
    }
}