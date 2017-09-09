using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : Scene {
	public RectTransform _scroll;
	private Vector2 _before_pos;
	private AudioSource _se;
	private int _next;
	private int _count;
	private const int WAIT_COUNT = 10;

	void Start () {
		_next = -1;
		_count = 0;
		_se = GetComponent< AudioSource >( );
	}
	

	void Update () {
		
		if ( Device.getTouchPhase( ) == Device.PHASE.BEGAN ) {
			_before_pos = Device.getPos( );
		}
		if ( Device.getTouchPhase( ) == Device.PHASE.MOVED ) {
			Vector2 pos = Device.getPos( );
			Vector3 vec = pos - _before_pos;
			vec.y = 0;
			_before_pos = pos;
			_scroll.position += vec;
			if ( _scroll.localPosition.x < -1770 ) {
				_scroll.localPosition = Vector2.right * -1770 + Vector2.up * _scroll.localPosition.y;
				
			}
			if ( _scroll.localPosition.x > 0 ) {
				_scroll.localPosition = Vector2.right * 0 + Vector2.up * _scroll.localPosition.y;
			}
		}

		if ( _next >= 0 ) {
				_count++;
			if ( _count > WAIT_COUNT ) {
				setStage( _next );
				SceneManager.LoadScene( "Scenario" );
			}
		}
	}

	public void setNext( int stage ) {
		_se.Play( );
		_next = stage;
		_count = 0;
	}
}
