using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.UpArrow)) {
			this.gameObject.transform.Translate (0,0,1*Time.deltaTime);		
		}
		if(Input.GetKey(KeyCode.UpArrow)){
			this.gameObject.transform.Translate (0,0,1*Time.deltaTime);
		}else if (Input.GetKey(KeyCode.DownArrow)){
			this.gameObject.transform.Translate (0,0,-1*Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.LeftArrow)){
			this.gameObject.transform.Rotate (0,-1,0);
		}
		else if (Input.GetKey(KeyCode.RightArrow)){
			this.gameObject.transform.Rotate (0,1,0);
		}

	}
} 	

