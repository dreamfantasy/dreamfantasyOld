using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : Scene {
	public RectTransform _scroll;
	private Vector2 _before_pos;
	private AudioSource _se;

	void Start( ) {
		_se = GetComponent< AudioSource >( );
	}
	

	void Update( ) {
		
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
	}

	public void selectStage( int stage ) {
		_se.Play( );
		setStage( stage );
		SceneManager.LoadScene( "Scenario" + getChapter( ) + "_" + stage );
	}
}
