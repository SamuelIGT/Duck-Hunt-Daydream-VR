using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckController : MonoBehaviour {
	private Vector3 dir;
	private Vector3 angle;

	public float minAngleX;
	public float maxAngleX;
	public float minAngleY;
	public float maxAngleY;
	public float speed;
	// Use this for initialization
	void Start () {
		angle = lookAngle ();
		transform.LookAt (angle);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += (transform.forward * speed) * Time.deltaTime;
		//transform.position += (Vector3.forward * speed) * Time.deltaTime;
		
	}
	private Vector3 lookAngle(){
		float x = Random.Range (minAngleX, maxAngleX);
		float y = Random.Range (minAngleY, maxAngleY);
		return new Vector3 (x, y, 0);
	}

    public void DetectHit() {
        Destroy(this.gameObject);
    }
}
