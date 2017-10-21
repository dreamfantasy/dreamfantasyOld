using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : Scene {

	// Use this for initialization
	void Start () {
		setTutorial( true );
		SceneManager.LoadScene( "Title" );
	}
	
	// Update is called once per frame
	void Update () {
	}
}
