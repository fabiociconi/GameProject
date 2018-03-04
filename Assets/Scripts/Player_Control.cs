using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour {

    public float maxSpeed = 10.0f;
  
    private SpriteRenderer sRend;
    private Rigidbody2D rBody;

    // Use this for initialization
    void Start () {
        rBody = GetComponent<Rigidbody2D>();
        sRend = GetComponent<SpriteRenderer>();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate(){
        float moveHoriz = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");

        

        //animator.SetFloat("speed", Mathf.Abs(moveVert));

        //Debug.Log("Horizontal " + moveHoriz + "Vertical" + moveVert);
        rBody.velocity = new Vector2(moveHoriz * maxSpeed, rBody.velocity.y);
       
        rBody.velocity = new Vector2(rBody.velocity.x, moveVert * maxSpeed);

        if (moveHoriz > 0 )
        {
            sRend.flipX = false;

        }
        else if (moveHoriz < 0 )
        {
            sRend.flipX = true;
        }




    }
 }
