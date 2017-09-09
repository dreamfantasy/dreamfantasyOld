using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

[System.Serializable]
public class Novel {
	public string scenario;
	public int chara_number;
}

public class Scenario : Scene {
	public GameObject _chara0;
	public GameObject _chara1;
	public GameObject _parentObject;
	public Novel[ ] _novels;
	private int _line = 0;
	private AudioSource _audio_source;
	private List< GameObject > _chara0_list = new List< GameObject >( );
	private List< GameObject > _chara1_list = new List< GameObject >( );
	private const float INTERVAL = 230;
	// Use this for initialization
	void Start( ) {
		readText( );
		_audio_source = gameObject.GetComponent< AudioSource >( );
		_audio_source.Play( );
	}
	
	// Update is called once per frame
	void Update( ) {
		if ( Device.getTouchPhase( ) == Device.PHASE.BEGAN ) {
			if ( _line < _novels.Length ) {
				readText( );
			} else {
				SceneManager.LoadScene( "Play" + getStage( ) );
			}
		}
	}

	void readText( ) {
		for ( int i = 0; i < _chara0_list.Count; i++ ) {
			RectTransform trans = _chara0_list[ i ].GetComponent< RectTransform >( );
			trans.anchoredPosition = trans.anchoredPosition + Vector2.down * INTERVAL;
			if ( trans.anchoredPosition.y < INTERVAL ) {
				_chara0_list[ i ].SetActive( false );
			}
		}
		for ( int i = 0; i < _chara1_list.Count; i++ ) {
			RectTransform trans = _chara1_list[ i ].GetComponent< RectTransform >( );
			trans.anchoredPosition = trans.anchoredPosition + Vector2.down * INTERVAL;
			if ( trans.anchoredPosition.y < INTERVAL ) {
				_chara1_list[ i ].SetActive( false );
			}
		}

		if ( _novels[ _line ].chara_number == 0 ) {
			GameObject tmp = Instantiate( _chara0 );
			tmp.SetActive( true );
			tmp.transform.SetParent( _parentObject.transform, false );
			Text text = tmp.transform.Find( "Text" ).gameObject.GetComponent< Text >( );
			text.text = _novels[ _line ].scenario;
			_chara0_list.Add( tmp );
		} else {
			GameObject tmp = Instantiate( _chara1 );
			tmp.SetActive( true );
			tmp.transform.SetParent( _parentObject.transform, false );
			Text text = tmp.transform.Find( "Text" ).gameObject.GetComponent< Text >( );
			text.text = _novels[ _line ].scenario;
			_chara1_list.Add( tmp );
		}
		_line++;
	}

}
