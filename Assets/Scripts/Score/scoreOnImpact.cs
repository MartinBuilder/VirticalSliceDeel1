using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreOnImpact : MonoBehaviour {

	
	void Start () {
        GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "wood");
        Debug.Log("500 points");
    }
}
