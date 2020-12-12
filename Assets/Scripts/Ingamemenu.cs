using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ingamemenu : MonoBehaviour {

    private Canvas canvas;
    public GameObject IngameSettings;
    // Use this for initialization
    void Start () {
        canvas = GetComponent<Canvas>(); //Получение компонента Canvas
        IngameSettings.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IngameSettings.active)
            {
                IngameSettings.SetActive(false);
            } else IngameSettings.SetActive(true);

        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
