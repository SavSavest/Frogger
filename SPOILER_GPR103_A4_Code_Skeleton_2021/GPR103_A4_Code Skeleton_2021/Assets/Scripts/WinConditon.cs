using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.transform.gameObject.tag == "Player")
    {
        Destroy(this.gameObject);

    }
}

}


