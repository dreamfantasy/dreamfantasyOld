using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ( Device.getTouchPhase( ) == Device.PHASE.ENDED ) {
			SceneManager.LoadScene( "ChapterSelect" );
		}
	}
}
