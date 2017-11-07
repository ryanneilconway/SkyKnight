using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour {

    movement movement;
    public raycastForward hit;
    public int health = 100;
    public int damage = 20;
    public bool ultimateMode;
    public GameObject god;
    public Slider healthbar;
    public GameObject gameOver;
    

	// Use this for initialization
	void Start () {

        gameOver.SetActive(false);
        hit = GetComponentInChildren<raycastForward>();
        movement = GetComponent<movement>();
        healthbar.value = CalculateHealth();


    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.D))
        {
            Death();
        }

        if (Input.GetKeyDown(KeyCode.G))  
        {
            ultimateMode = !ultimateMode;
        }

        if (ultimateMode)
        {
            enableGodMode();
        }
        else
        {
            disableGodMode();
        }

        if (health <= 0)
        {
            Death();
        }

    }

    public void dealDamage(GameObject target)
    {
        if (target)
        {
            Zombie zombieTarget = target.GetComponent<Zombie>();
            if (movement.attacking && hit.attackable)
            {
                // deal damage to the enemy
                target.SendMessage("takeDamage", damage);
            }

            // Check if zombie is dead
            if (zombieTarget.getHealth() < 0)
            {
                //kills the zombie
                target.SendMessage("death");
            }
        }
    }


    public void takeDamage(int amount)
    {
        if (!ultimateMode)
        {
                health -= amount;
            updateHealthBar();
             
        }
    }

    public void updateHealthBar()
    {
        healthbar.value = CalculateHealth();
    }

    public void increaseHealth(int amount)
    {
        if (health >= 100)
        {
            health = 100;
            Debug.Log("Not Possible Health Is Full");
        }
        else
        {
            health += amount;
            Debug.Log("Healed for" + amount);
        }
        updateHealthBar();


    }



    int CalculateHealth()
    {
        return (health);

    }


    //Kill the player
    public void Death()
    {
        Debug.Log("DEATHCALLED");
        gameOver.SetActive(true);
        gameObject.SetActive(false);
    }



    //godmode box was checked in editor
    public void enableGodMode()
    {

        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.color = (Color.red);
        god.SetActive(true);



    }

    // godmode box was unchecked in editor

    public void disableGodMode()
    {
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.color = (Color.white);
        god.SetActive(false);

    }

}
