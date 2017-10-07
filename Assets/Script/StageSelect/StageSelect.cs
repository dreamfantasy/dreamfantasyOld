using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelect : Scene {
	public GameObject[ ] _button;
	private AudioSource _se;

	void Start( ) {
		_se = GetComponent< AudioSource >( );
		int size = _button.Length;
		for ( int i = 0; i < size; i++ ) {
			if ( !isClearStage( i ) ) {
				_button[ i ].GetComponent< Image >( ).color = new Color( 1, 0, 0 );
			}
		}
	}
	

	void Update( ) {
	}

	public void selectStage( int stage ) {
		_se.Play( );
		setStage( stage );
		SceneManager.LoadScene( "Scenario" );
	}

	public bool isClearStage( int stage ) {
		bool clear = false;
		if ( getClearStage( ) >= stage ) {
			clear = true;
		}
		return clear;
	}
}
