using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVScreenBlackout : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void blackoutScreen() {
        //gameObject.SetActive(true);
        GetComponent<Animator>().SetBool("blackoutScreen", true);
    }
}
