using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieAI : MonoBehaviour
{
    
    public int speed;
    public Transform target;
    public bool touching = false;
    public bool attacking = false;
    public Combat playerStats;



    // Use this for initialization
    void Start()
    {

        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        playerStats = target.GetComponent<Combat>();


    }

    // Update is called once per frame
    void Update()
    {

        if (target != null)
        {


            float step = (Time.deltaTime + speed / 50);
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);

            // detect if the player is to the left or right of the zombie using the X axis
            if (target.position.x < transform.localPosition.x)
            {
                playerLocation("left");
            }
            else
            {
                playerLocation("right");
            }

            if (touching && !attacking)
            {
                StartCoroutine(Attack());
                attacking = true;
           }
        }
    }

    private void FixedUpdate()
    {

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player") {

            touching = true;
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            touching = false;
            attacking = false;
            StopAllCoroutines();
        }
    }

    public IEnumerator Attack()
    {
        while (true && playerStats.health > 0)
        {
            yield return new WaitForSeconds(0.2f);
            gameObject.SendMessage("attack");
            yield return new WaitForSeconds(1);
           
        }
    }

    // face the direction of the player
    public void playerLocation(string direction)
    {
        if (direction == "left")
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }

        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }


}
