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

		if (Input.GetKeyDown ("0")) {
			setStage (0);
			SceneManager.LoadScene ("Play");
		}

		if (Input.GetKeyDown ("1")) {
			setStage (1);
			SceneManager.LoadScene ("Play");
		}

		if (Input.GetKeyDown ("2")) {
			setStage (2);
			SceneManager.LoadScene ("Play");
		}

		if (Input.GetKeyDown ("3")) {
			setStage (3);
			SceneManager.LoadScene ("Play");
		}
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

	public GameObject getButton( int idx ) {
		return _button[ idx ];
	}
}
