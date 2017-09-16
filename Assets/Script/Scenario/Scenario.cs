using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;



public class Scenario : Scene {
	public GameObject _text_box;
	public GameObject _parentObject;
	private string[ ] _novels;
	private int _line = 0;
	private AudioSource _bgm;
	private List< GameObject > _text_list = new List< GameObject >( );
	private const float INTERVAL = 260;
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
		for ( int i = 0; i < _text_list.Count; i++ ) {
			RectTransform trans = _text_list[ i ].GetComponent< RectTransform >( );
			trans.anchoredPosition = trans.anchoredPosition + Vector2.down * INTERVAL;
			if ( trans.anchoredPosition.y < INTERVAL / 2 ) {
				_text_list[ i ].SetActive( false );
			}
		}
		GameObject tmp = Instantiate( _text_box );
		tmp.SetActive( true );
		tmp.transform.SetParent( _parentObject.transform, false );
		Text text = tmp.transform.Find( "Text" ).gameObject.GetComponent< Text >( );
		text.text = _novels[ _line ];
		_text_list.Add( tmp );
		
		_line++;
	}

	public void loadScenePlay( ) {
		if ( isTutorial( ) ) {
			SceneManager.LoadScene( "PlayTutorial" );
		} else {
			if ( getStage( ) < 3 ) {
				SceneManager.LoadScene( "Play" + getChapter( ) + "_" + getStage( ) );
			} else {
				setTutorial( true );
				SceneManager.LoadScene( "Title" );
			}
		}
	}

}
