using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Title : Scene {
	public Image touch_to_start;
	private float _alpha_speed = 0.01f;
	private AudioSource _bgm;
	//private VideoPlayer _video;
	private int _count;

	private const int WAIT_TIME = 150;

	// Use this for initialization
	void Start( ) {
		touch_to_start.color = new Color( 1, 1, 1, 0 );
		_bgm = gameObject.GetComponent< AudioSource >( );
		_bgm.Play( );
		setStage( 0 );
		//_video = gameObject.GetComponent< VideoPlayer >( );
		//_video.Stop( );
	}
	
	// Update is called once per frame
	void Update( ) {
		_count++;
		if ( _count > WAIT_TIME ) {
			//if ( !_video.isPlaying ) {
			//	_video.Play( );
			//}
		}


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
			//if ( _video.isPlaying ) {
			//	_count = 0;
			//	_video.Stop( );
			//} else {
				if ( isTutorial( ) ) {
					SceneManager.LoadScene( "Scenario" );
				} else {
					//SceneManager.LoadScene( "ChapterSelect" );
					SceneManager.LoadScene( "StageSelect0" );
				}
			//}
		}

		if ( !_bgm.isPlaying ) {
			_bgm.Play( );
		}


		if (Input.GetKeyDown ("0")) {
			setTutorial (false);
			setStage (0);
			SceneManager.LoadScene ("Play");
		}

		if (Input.GetKeyDown ("1")) {
			setTutorial (false);
			setStage (1);
			SceneManager.LoadScene ("Play");
		}

		if (Input.GetKeyDown ("2")) {
			setTutorial (false);
			setStage (2);
			SceneManager.LoadScene ("Play");
		}

		if (Input.GetKeyDown ("3")) {
			setTutorial (false);
			setStage (3);
			SceneManager.LoadScene ("Play");
		}

		if (Input.GetKeyDown ("4")) {
			setTutorial (false);
			setStage (4);
			SceneManager.LoadScene ("Play");
		}
	}
}
