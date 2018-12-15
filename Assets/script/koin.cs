using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class koin : MonoBehaviour {

    gerak objekgerak;
    // Use this for initialization
    void Start()
    {
        objekgerak = GameObject.Find("player").GetComponent<gerak>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "Player")
        {
            objekgerak.koin++;
            Destroy(gameObject);
        }
    }
}
