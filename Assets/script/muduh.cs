using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muduh : MonoBehaviour {

    gerak objekgerak;
	// Use this for initialization
	void Start () {
        objekgerak = GameObject.Find("player").GetComponent<gerak>();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.transform.tag == "Player")
        {
            //print("anda tersentuh player");
            //Destroy(objekgerak.gameObject);
            objekgerak.nyawa--;
            objekgerak.ulang = true;
        }
    }
}
