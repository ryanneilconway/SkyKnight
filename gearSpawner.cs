using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gearSpawner : MonoBehaviour {

    public GameObject[] gear;
    //GameObject myGearClone;

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SpawnMedkit()
    {

        Instantiate(gear[0], transform.position, Quaternion.identity);

    }

    public void SpawnDamageBoost()
    {

        Instantiate(gear[1], transform.position, Quaternion.identity);

    }


}