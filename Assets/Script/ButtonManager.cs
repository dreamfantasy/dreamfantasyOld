using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnSkip( ) {
		SceneManager.LoadScene( "Play" );
	}

	public void OnRetire( ) {
		SceneManager.LoadScene( "Title" );
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
