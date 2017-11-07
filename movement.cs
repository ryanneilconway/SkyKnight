using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Combat combat;
    private raycastForward raycast;
    public bool grounded;
    public float speed;
    public bool attacking;
    public bool jumping;
    public float jumpPower;
    public float attackSpeed;
    public bool running;
    public bool ceiling;


	// Use this for initialization
	void Start () {

        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        combat = gameObject.GetComponent<Combat>();
        raycast = GetComponentInChildren<raycastForward>();


    }
	
	// Update is called once per frame
	void Update () {

        getInputKey();
        isGrounded();
        isCeiling();

        if (attacking)
        {
            anim.SetBool("Attacking", true);
        }
        else
        {
            anim.SetBool("Attacking", false);
        }

        if (running)
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }

    }

    void getInputKey()
    {

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                MoveLeft();
            }
            else
            {
                MoveRight();
            }
        }

        else
        {
            running = false;
        }



        if (Input.GetKey(KeyCode.DownArrow) && !attacking)
        {
            StartCoroutine(fire());
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && !jumping && grounded)
        {
            Jump();
        }
    }



    // left arrow key was pressed
    void MoveLeft() {
        if (!attacking)
        {
            running = true;
            transform.Translate(Vector2.left * (Time.deltaTime + speed / 50), Space.World);
            gameObject.transform.localEulerAngles = new Vector2(0, 180);
        }
    }

    // right arrow key was pressed
    void MoveRight()
    {
        if (!attacking)
        {
            running = true;
            transform.Translate(Vector2.right * (Time.deltaTime + speed / 50), Space.World);
            gameObject.transform.localEulerAngles = new Vector2(0, 0);
        }
    }


    // check if the player is on the ground
    void isGrounded()
    {
        if (grounded)
        {
            //Player on the ground
            anim.SetBool("Grounded", true);

        }
        else
        {
            //Player in the air
        }

    }

    void isCeiling()
    {
        if (ceiling)
        {
            Debug.Log("Ceiling Hit");
        }

        // asbsolute world limit height
        if (transform.position.y > 5)
        {
            transform.Translate(Vector2.down);
        }

    }

    // Down attack arrow key was pressed
    IEnumerator fire()
    {
        running = false;
        attacking = true;
        combat.dealDamage(raycast.getTarget());
        yield return new WaitForSeconds(attackSpeed);
        attacking = false;
        StopCoroutine(fire());
    }

    // Jump up arrow key was pressed
    public void Jump()
    {
        anim.SetBool("Running", false);
        anim.SetBool("Attacking", false);
        anim.SetBool("Grounded", false);
        attacking = false;
        grounded = false;
        jumping = true;
        rb.AddForce((Vector2.up) * jumpPower);
        jumping = false;
    }

}
