using UnityEngine.SceneManagement;
using UnityEngine;

public class Result : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ( Device.getTouchPhase( ) == Device.PHASE.ENDED ) {
			SceneManager.LoadScene( "StageSelect" );
		}
	}
}
