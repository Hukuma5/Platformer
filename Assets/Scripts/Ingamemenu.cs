using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingamemenu : MonoBehaviour {

    private Canvas canvas;
    // Use this for initialization
    void Start () {
        canvas = GetComponent<Canvas>(); //Получение компонента Canvas
        canvas.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.enabled = !canvas.enabled; //При нажатии на кнопку I окно будет отображаться или скрываться
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
