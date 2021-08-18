using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryFly : MonoBehaviour
{
    public RandomFlySpawn flySpawn;
   
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestruct());
        GameObject f = GameObject.FindGameObjectWithTag("Fly");
        flySpawn = f.GetComponent<RandomFlySpawn>();
       
        
    }

    // Update is called once per frame
  IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(Random.Range(1f, 15f));
        Destroy(gameObject);
        flySpawn.flyHasSpawned = false;
        
    }
}
