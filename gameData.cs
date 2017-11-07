using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameData : MonoBehaviour {

    public int totalZombieHealth;
    public int durationOfWave;
    public int totalPlayerDamageTaken;
    public bool waveStarted;



    static public Countdown tick;
    public GameObject[] spawnObjects;
    static public BPMain[] neuralNetworks;
    static public gearSpawner gearSpawner;
    static public Text zombieAmountText;
    static public Text timeAmountText;
    static public Text waveAmountText;
    public int waveCount;
    public double[] totalData = new double[4];
    public Combat player;
    

    // Use this for initialization
    void Start () {
        tick = gameObject.GetComponent<Countdown>();
        gearSpawner = GameObject.FindGameObjectWithTag("spawnleft").GetComponent<gearSpawner>();
        zombieAmountText = GameObject.FindGameObjectWithTag("zombievalue").GetComponent<Text>();
        timeAmountText = GameObject.FindGameObjectWithTag("timevalue").GetComponent<Text>();
        waveAmountText = GameObject.FindGameObjectWithTag("wavevalue").GetComponent<Text>();
        spawnObjects = GameObject.FindGameObjectsWithTag("spawnright");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Combat>();

       
 
        waveCount = -1;

    }
	
	// Update is called once per frame
	void Update ()
    {

        updateText();
        checkTimer();
        totalZombieHealth = getZombiesHealth();


    }

    private void totalDataUpdate()
    {
            totalData[0] = Zombie.getZombieCount();
            totalData[1] = totalZombieHealth;
            totalData[2] = player.health;
            totalData[3] = Zombie.getDistance();

    }

    private void checkTimer()
    {    
        if (!tick.isCountingDown)
        {
            tick.Begin();
            checkZombiesLeft();
        }
    }

    private void checkZombiesLeft()
    {
        if (Zombie.getZombieCount() == 0)
        {


            print("Recalculating Decision Making");

            spawnNextWave();
        }
       
    }
     


    private void updateText()
    {
        zombieAmountText.text = (Zombie.getZombieCount()).ToString();
        timeAmountText.text = (tick.timeRemaining).ToString();
        waveAmountText.text = (waveCount).ToString();
    }

    private void spawnNextWave()
    {
       if (waveCount >= 0) {
            for (int i = 0; i < spawnObjects.Length; i++)
            {
       
                StartCoroutine(spawnObjects[i].GetComponent<spawner>().SpawnZombie(1));
              

            }
            waveStarted = true;
            gearSpawner.SpawnMedkit();
        }

        waveCount++;
    }


    private void grabNetworks()
    {
        if (waveStarted)
            for (int i = 0; i < spawnObjects.Length; i++)
            {
                neuralNetworks[i] = spawnObjects[i].GetComponent<BPMain>();
            }
        }

    public int getZombiesHealth()
    {
        int health = 0;
        for (int i = 0; i < Zombie.AllEnemies.Count ; i++)
        {
          health += Zombie.AllEnemies[i].GetComponent<Zombie>().getHealth();
        }

        return health;
       
    }
}
