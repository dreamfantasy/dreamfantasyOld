using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SceneManager.LoadScene( "TitleTutorial" );
	}
	
	// Update is called once per frame
	void Update () {
	}
}
