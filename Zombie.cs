using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie : MonoBehaviour {

    public int health;
    public int damage;
    public int scoreValue;
    public double distance;
    public Slider enemySlider;
    static GameObject player;
    Score playerScore;
    private static List<GameObject> allEnemies = new List<GameObject>();
    private static GameObject self;

    public static List<GameObject> AllEnemies
    {
        get
        {
            return allEnemies;
        }

        set
        {
            allEnemies = value;
        }
    }

    public static int getZombieCount()
    {
        return AllEnemies.Count;
    }

    void Awake()
    {
        AllEnemies.Add(gameObject);
    }

     void OnDestroy()
    {
        AllEnemies.Remove(gameObject);
    }

    public void Start()
    {
        
        enemySlider.maxValue = health;
        enemySlider.value = health;
        player = GameObject.FindGameObjectWithTag("Player");
        playerScore = player.GetComponent<Score>();
        self = gameObject;
        gameObject.GetComponent<BPMain>().TrainTheBrain();


    }

    // set health of zombie
    public void setHealth(int health)
    {
        this.health = health;
    }

    // set damage zombie can deal
    public void setDamage(int damage)
    {
        this.damage = damage;
    }

    // returns the zombies health
    public int getHealth()
    {
        return this.health;
    }

    // returns the zombies damage (attackpower)
    public int getDamage()
    {
        return this.damage;
    }

    // deals damage to the zombies health
    public void takeDamage(int damage)
    {
        //enemySlider.gameObject.SetActive(true);
        this.health -= damage;
        enemySlider.value = health;
    }

    public static double getDistance()
    {
       return Vector2.Distance(self.transform.position, player.transform.position);
    }




    // allows the zombie to attack the player
    public void attack() {
        GameObject.FindGameObjectWithTag("Player").SendMessage("takeDamage", damage);
    }

    // when the player kills the zombie
    public void death()
    {
        Destroy(gameObject);
        playerScore.increaseScore(scoreValue);

    }

}
