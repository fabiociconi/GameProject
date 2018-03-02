using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            anim.SetBool("Walk", true);
            anim.SetBool("Atack", false);
            return;
        }

        if (Input.GetKey("a"))
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Atack", true);
            return;
        }

        if (Input.GetKey("s"))
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Atack", false);
        }
        
    }
}
