using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocSpawn : MonoBehaviour
{
    public GameObject croc1, croc2, croc3, croc4, croc5;
    public float spawnRate = 0;
    public float nextSpawn = 0f;
    public int whichCroc;
    public bool crocHasSpawned = false;
    public float refreshSpawn = 0;

    // Start is called before the first frame update

    void Awake()
    {
        


    }
    void Start()
    {
        spawnRate = Random.Range(10, 30);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Time.time > nextSpawn && crocHasSpawned == false)
        {
            // I don't want crocs to spawn as frequently as flys
            whichCroc = Random.Range(1, 10);
            Debug.Log(whichCroc);
            crocHasSpawned = true;
            SpawnCroc();
             nextSpawn = Time.time + spawnRate;
        }




    }

    void SpawnCroc()
    {
        Vector2 pos1 = new Vector2(-8, 7);
        Vector2 pos2 = new Vector2(-4, 7);
        Vector2 pos3 = new Vector2(0, 7);
        Vector2 pos4 = new Vector2(4, 7);
        Vector2 pos5 = new Vector2(8, 7);


        switch (whichCroc)
        {
            case 1:
                Instantiate(croc1, pos1, Quaternion.identity);
                break;
            case 2:
                Instantiate(croc2, pos2, Quaternion.identity);
                break;
            case 3:
                Instantiate(croc3, pos3, Quaternion.identity);
                break;
            case 4:
                Instantiate(croc4, pos4, Quaternion.identity);
                break;
            case 5:
                Instantiate(croc5, pos5, Quaternion.identity);
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Bonus")
        {
            Destroy(collision.gameObject);
        }
    }
}
