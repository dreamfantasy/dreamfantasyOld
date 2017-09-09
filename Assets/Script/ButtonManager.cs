using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : Scene {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnSkip( ) {
		SceneManager.LoadScene( "Play" + getStage( ) );
	}

	public void OnRetire( ) {
		SceneManager.LoadScene( "StageSelect" );
	}

	public void OnSelectChapter1( ) {
		SceneManager.LoadScene( "StageSelect" );
	}

	public void OnSelectChapter2( ) {
		SceneManager.LoadScene( "StageSelect" );
	}

	public void OnSelectChapter3( ) {
		SceneManager.LoadScene( "StageSelect" );
	}
}
