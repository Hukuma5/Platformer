using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Entering : MonoBehaviour
{
    public GameObject Entry;
    public GameObject LoadingBarShop;
    //public GameObject Image;   //Android
    private bool flag = false;
    public Vector3 position;
    public VectorValue playerStroge;
    private CharacterControllerScript player;
    private void Start()
    {
        player = FindObjectOfType<CharacterControllerScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        flag = !flag;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        flag = !flag;
    }

    private void Update()
    {
        //if (flag == true) Image.SetActive(true); else Image.SetActive(false);//Android
        if (flag && Input.GetKeyDown(KeyCode.W))
        {
            playerStroge.InitialValue = position;
            Debug.Log("flag");
            SaveLoad.AutoSaveGame(player);
            Debug.Log("saved");
            CharacterControllerScript.previousScene = "dungeon";
            LoadingBarShop.SetActive(true);
        }
 
    }

    //Only for Android
    public void Enter()
    {
        if (flag) LoadingBarShop.SetActive(true);
    }
}