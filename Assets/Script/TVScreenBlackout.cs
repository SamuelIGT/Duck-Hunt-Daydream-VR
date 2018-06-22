using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TVScreenBlackout : MonoBehaviour {
    public EyeBlink eyeBlink;
    public float blinkDelayInSeconds;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void blackoutScreen() {
        //gameObject.SetActive(true);
        Animator animator = GetComponent<Animator>();
        animator.SetBool("blackoutScreen", true);

        Invoke("blinkEye", blinkDelayInSeconds);

        Invoke("changeScene", blinkDelayInSeconds*4);


        //if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 /*&& ("Screen Blackout")*/) {
        //    Debug.Log("Animação acabou!");
        //}
    }

    private void blinkEye()
    {
        eyeBlink.blinkEye();
    }

    private void changeScene()
    {
        SceneManager.LoadScene("Fase 1");
    }

}
