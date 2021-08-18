using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFlySpawn : MonoBehaviour
{
   
   public GameObject fly1, fly2, fly3, fly4, fly5;

    public float spawnRate = 0;
    public float nextSpawn = 0f;
    public int whichFly;
    public bool flyHasSpawned = false;
    public float refreshSpawn = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnRate = Random.Range(1, 15);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn && flyHasSpawned == false)
        {
            whichFly = Random.Range(1, 5);
            Debug.Log(whichFly);

            SpawnFly();

            nextSpawn = Time.time + spawnRate;
            //flyHasSpawned = true;
            // need to work out how to change fly spawn to false upon destruction
        }

       
              

    }

void SpawnFly()
    {
        Vector2 flyPosition = new Vector2(Random.Range(-4, 4), Random.Range(4, 4));
        switch (whichFly)
        {
            case 1:
                Instantiate(fly1, flyPosition, Quaternion.identity);
                
                break;
            case 2:
                Instantiate(fly2, flyPosition, Quaternion.identity);
                break;
            case 3:
                Instantiate(fly3, flyPosition, Quaternion.identity);
                break;
            case 4:
                Instantiate(fly4, flyPosition, Quaternion.identity);
                break;
            case 5:
                Instantiate(fly5, flyPosition, Quaternion.identity);
                break;
        }
    }
  
}



//References
//https://www.youtube.com/watch?v=ao_BZMORqQw&ab_channel=AlexanderZotov
//https://answers.unity.com/questions/875343/random-spawn-timer.html

