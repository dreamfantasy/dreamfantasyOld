using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour {
	public RectTransform _scroll;
	private Vector2 _before_pos;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		if ( Device.getTouchPhase( ) == Device.PHASE.BEGAN ) {
			_before_pos = Device.getPos( );
		}
		if ( Device.getTouchPhase( ) == Device.PHASE.MOVED ) {
			Vector2 pos = Device.getPos( );
			Vector3 vec = Vector3.zero;
			vec.x = ( pos.x - _before_pos.x );
			_before_pos = pos;
			_scroll.position += vec;
			if ( _scroll.anchoredPosition.x < -2500 + Screen.width * 1.7 ) {
				_scroll.anchoredPosition = Vector2.right * ( -2500 + (int)( Screen.width * 1.7 ) );
			}
			if ( _scroll.position.x > 0 ) {
				_scroll.position = Vector3.right * 0;
			}
		}
	}

	public void setNext ( ) {
		SceneManager.LoadScene( "Scenario" );
	}
}
