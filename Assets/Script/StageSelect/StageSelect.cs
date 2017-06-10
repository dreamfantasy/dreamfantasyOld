using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour {
	public RectTransform _camera;
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
			_camera.position += vec;
			if ( _camera.anchoredPosition.x < -2800 ) {
				_camera.anchoredPosition = Vector2.right * -2800;
			}
			if ( _camera.position.x > 0 ) {
				_camera.position = Vector3.right * 0;
			}
		}
	}

	public void setNext ( ) {
		SceneManager.LoadScene( "Scenario" );
	}
}
