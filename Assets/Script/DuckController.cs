using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckController : MonoBehaviour {
    private Vector3 dir;
    private Vector3 angle;

    public GameObject explosionFX;

    public float minAngleX;
    public float maxAngleX;
    public float minAngleY;
    public float maxAngleY;
    public float speed;

    public long rewardScore = 100;
    public int maxLife = 1;
    //public GameObject gameController;
    private ScoreController scoreController;

    private int currentLife;
    // Use this for initialization
    void Start()
    {
        currentLife = maxLife;
        angle = lookAngle();
        transform.LookAt(angle);
        scoreController = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (transform.forward * speed) * Time.deltaTime;
    }
    private Vector3 lookAngle()
    {
        float x = Random.Range(minAngleX, maxAngleX);
        float y = Random.Range(minAngleY, maxAngleY);
        return new Vector3(x, y, 0);
    }

    public void DetectHit()
    {
        currentLife--;
        if(currentLife <= 0)
        {
            GameObject explosion = Instantiate(explosionFX) as GameObject;
            explosion.transform.position = this.transform.position;
            Destroy(this.gameObject);

            scoreController.setDucksKilledCount(1);
            scoreController.increaseScore(rewardScore);
            //TODO: notificar score que um alvo foi eliminado
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ("BOUNDARY".Equals(other.tag)) {
            Destroy(this.gameObject);
            //TODO: notificar score que um alvo foi perdido
        }
    }
}
