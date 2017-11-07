using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

    public GameObject[] zombies;
    public int spawnDelay = 1;
   

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public IEnumerator SpawnZombie(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            yield return new WaitForSeconds(spawnDelay);
            Instantiate(zombies[0], transform.position, Quaternion.identity);
        }
        yield break;
     }

    public IEnumerator SpawnBoss(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            yield return new WaitForSeconds(spawnDelay);
            Instantiate(zombies[1], transform.position, Quaternion.identity);
        }
      
    }



}
