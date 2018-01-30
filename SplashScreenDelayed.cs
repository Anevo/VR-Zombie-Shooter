using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenDelayed : MonoBehaviour {

    public float delayTime = 5;

	// Use this for initialization
	IEnumerator Start () {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(1);
	}
	


	// Update is called once per frame
	void Update () {
		
	}
}
