using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : Scene {
	public Image touch_to_start;
	private float _alpha_speed = 0.01f;
	private AudioSource _bgm;
	// Use this for initialization
	void Start( ) {
		touch_to_start.color = new Color( 1, 1, 1, 0 );
		_bgm = gameObject.GetComponent< AudioSource >( );
		_bgm.Play( );
		setStage( 0 );
	}
	
	// Update is called once per frame
	void Update( ) {
		float alpha = touch_to_start.color.a;
		alpha += _alpha_speed;
		if ( _alpha_speed > 0 ) {
			if ( alpha > 1 ) {
				alpha = 1;
				_alpha_speed *= -1;
			}
		} else {
			if ( alpha < 0 ) {
				alpha = 0;
				_alpha_speed *= -1;
			}
		}
		touch_to_start.color = new Color( 1, 1, 1, alpha );

		
		if ( Device.getTouchPhase( ) == Device.PHASE.ENDED ) {
			if ( isTutorial( ) ) {
				SceneManager.LoadScene( "Scenario" );
			} else {
				//SceneManager.LoadScene( "ChapterSelect" );
				SceneManager.LoadScene( "StageSelect0" );
			}
		}
		if ( !_bgm.isPlaying ) {
			_bgm.Play( );
		}
	}
}
