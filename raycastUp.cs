using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastUp : MonoBehaviour
{

    GameObject player;
    Rigidbody2D rb;
    movement movement;
    public float length;
    public float distanceFromContact;
    public float velocity;
    public bool showRayVisual;

    // Use this for initialization
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");


        movement = player.GetComponent<movement>();


    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
        Vector2 up = transform.TransformDirection(Vector2.up) * length;

        if (showRayVisual)
        {
            Debug.DrawRay(transform.position, up, Color.red);
        }

        distanceFromContact = (transform.position.y - hit.point.y);


        if (distanceFromContact == 0)
        {
            // player is near a ceiling
            movement.ceiling = true;


        }

        else
        {
            // player is not near a ceiling
            movement.ceiling = false;

        }

    }
}
