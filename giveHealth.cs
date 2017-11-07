using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giveHealth : MonoBehaviour {

    public int amount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            addHealth(other.tag);
        }
        else
        {
            //Physics2D.IgnoreCollision(other.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other.GetComponent<Collider2D>());
        }


    }

    public void addHealth(string tag)
    {
        Combat script = GameObject.FindGameObjectWithTag(tag).GetComponent<Combat>();
        script.increaseHealth(amount);
        destroyHealthKit();
    }

  public void destroyHealthKit()
    {
        Destroy(gameObject);
    }

    public void Start()
    {
       
    } 



}
