using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastDown : MonoBehaviour {

    GameObject player;
    Rigidbody2D rb;
    movement movement;
    public float length;
    public float distanceFromContact;
    public float velocity;
    public bool showRayVisual;

	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
        

        movement = player.GetComponent<movement>();

		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        Vector2 down = transform.TransformDirection(Vector2.down) * length;

        if (showRayVisual) {
        Debug.DrawRay(transform.position, down, Color.red);
        }

        distanceFromContact = (transform.position.y - hit.point.y );
        velocity = Mathf.Round(player.GetComponent<Rigidbody2D>().velocity.y);

        if ((distanceFromContact != 0) && (player.GetComponent<Rigidbody2D>().velocity.y != 0)  )
        {
            // player is in the air
            movement.grounded = false;
         
           
        }

        else
        {
            // player is on the ground
            movement.grounded = true;

        }
		
	}
}
