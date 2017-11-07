using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastForward : MonoBehaviour
{

    public float theDistance;
    public float maxDistance;
    public GameObject target;
    public bool attackable;
    public bool showRayVisual;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        rayCast();

    }

    void rayCast()

    {

        Vector2 direction = transform.TransformDirection(Vector2.right);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, maxDistance);


        if (showRayVisual)
        {
            // show the raycast visual
            Debug.DrawRay(transform.position, direction * maxDistance, Color.red);
        }

        // raycast hit something
        if (hit.collider != null)
        {
            bool objectHit = hit.transform.gameObject.CompareTag("zombie");
            
            // if the raycast hit a zombie
            if (objectHit)
            {
               
                setTarget(hit.transform.gameObject);
                attackable = true;
            }

        }

        else
        {
            // if the raycast did not hit a zombie
            setTarget(null);
            attackable = false;
        }





    }



    

    public GameObject getTarget()
    {
        return this.target;
    }

    public void setTarget(GameObject target)
    {
        this.target = target;
    }

}
