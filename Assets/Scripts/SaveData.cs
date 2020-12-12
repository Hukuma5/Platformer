using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int currHP;
    public int HP;
    public float[] position;

    public SaveData(CharacterControllerScript character)
    {

        HP = character.maxhp;
        currHP = character.hp;

        position = new float[3]
        {
            character.transform.position.x,
            character.transform.position.y,
            character.transform.position.z
        };
    }

}