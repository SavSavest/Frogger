using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCroc : MonoBehaviour
{  
    public bool isSpawned = false;

    
    void Start()
    {
        isSpawned = true;
        CrocDestroy();
    }

    void Update()
    {
        CrocDestroy();
    }

    void CrocDestroy()
    {
        if (isSpawned == true)
        {
            StartCoroutine(SelfDestruct());
        }
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(Random.Range(1f, 15f));
        Destroy(gameObject);
        isSpawned = false;
    }
}
            


       
   

