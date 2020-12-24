using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black : MonoBehaviour
{
    private Animator anim;
    private CameraFollow2D cam;
    private CharacterControllerScript player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        cam = FindObjectOfType<CameraFollow2D>();
        player = FindObjectOfType<CharacterControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(player.transform.position.x - cam.transform.position.x) > 15f || Mathf.Abs(player.transform.position.y - cam.transform.position.y) > 15f)
        {
            anim.Play("Dark");
            cam.FindPlayer(true);
        }
    }
}
