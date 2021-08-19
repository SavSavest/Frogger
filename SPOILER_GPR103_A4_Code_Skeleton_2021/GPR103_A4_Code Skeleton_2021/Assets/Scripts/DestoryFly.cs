using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryFly : MonoBehaviour
{
    public GameObject flySpawn;
    public bool isSpawned = false;
   
    // Start is called before the first frame update
    void Start()
    {
        isSpawned = true;
        FlyDestroy();
    }

    void Update()
    {

        //I was trying to work out how to make it so if there is a fly spawned no more will spawn until it is destroyed
        //The prefabs would not recognise any object within a scene. I've tried calling
        //functions from another script but I can't seem to get it working. I'm moving on.
        //The flies spawn and despawn, there's just several at once sometimes. Secret bonus score, I guess.

        //flySpawn = GameObject.FindGameObjectsWithTag("Bonus");
        //flyIsSpawning = flySpawn.GetComponent<RandomFlySpawn>();

    }

    void FlyDestroy()
    {
        if (isSpawned == true)
        {
            StartCoroutine(SelfDestruct());
            //flyIsSpawning.flyHasSpawned = false;
        }

    }

    // Update is called once per frame
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(Random.Range(1f, 15f));
        Destroy(gameObject);
        isSpawned = false;  
        
    }
}
