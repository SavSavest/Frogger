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

        FlyDestroy();


    }

    void FlyDestroy()
    {
        if (isSpawned == true)
        {
            StartCoroutine(SelfDestruct());
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
