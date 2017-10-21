using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;



public class Scenario : Scene {
	public Text _text;
	public Text _name;
	private ScenarioNovel.Novel[ ] _novels;
	private int _line = 0;
	private AudioSource _bgm;
	private const float INTERVAL = 260;
	
	//待機系
	private int _wait_count = 0;
	private const int WAIT_TIME = 60;

	// Use this for initialization
	void Start( ) {
		GameObject novel;
		if ( isTutorial( ) ) {
			novel = ( GameObject )Resources.Load( "Prefab/Scenario/ScenarioTurorial" );
		} else {
			if ( getStage( ) < 3 ) {
				novel = ( GameObject )Resources.Load( "Prefab/Scenario/Scenario" + getChapter( ).ToString( ) + "_" + getStage( ).ToString( ) );
			} else {
				novel = ( GameObject )Resources.Load( "Prefab/Scenario/ScenarioEnd" );
			}
		}
		_novels = novel.GetComponent< ScenarioNovel >( ).getNovel( );
		_bgm = gameObject.GetComponent< AudioSource >( );
		_bgm.Play( );
		readText( );
	}
	
	// Update is called once per frame
	void Update( ) {
		if ( _wait_count < WAIT_TIME ) {
			_wait_count++;
			return;
		}
		if ( Device.getTouchPhase( ) == Device.PHASE.BEGAN ) {
			if ( _line < _novels.Length ) {
				readText( );
			} else {
				loadScenePlay( );
			}
		}

		if ( !_bgm.isPlaying ) {
			_bgm.Play( );
		}
	}

	void readText( ) {
		_text.text = _novels[ _line ].text;
		_name.text = _novels[ _line ].name;
		_line++;
	}

	public void loadScenePlay( ) {
		if ( isTutorial( ) ) {
			SceneManager.LoadScene( "PlayTutorial" );
		} else {
			if ( getStage( ) < 3 ) {
				SceneManager.LoadScene( "Play" );
			} else {
				setTutorial( true );
				SceneManager.LoadScene( "Title" );
			}
		}
	}

}
