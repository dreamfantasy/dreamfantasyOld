using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {
	public GameObject touch_to_start;
	private const int AVTIVE_CHANGE_COUNT = 50;
	private int _active_count;
	// Use this for initialization
	void Start ( ) {
		_active_count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		_active_count++;
		if ( _active_count % AVTIVE_CHANGE_COUNT == 0 ) {
			touch_to_start.SetActive( !touch_to_start.activeSelf );
		}
		if ( Device.getTouchPhase( ) == Device.PHASE.ENDED ) {
			SceneManager.LoadScene( "ChapterSelect" );
		}
	}
}
