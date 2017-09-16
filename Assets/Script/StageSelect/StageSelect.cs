using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : Scene {
	public GameObject[ ] _button;
	private AudioSource _se;

	void Start( ) {
		_se = GetComponent< AudioSource >( );
		int size = _button.Length;
		int clear_stage = getClearStage( );
		for ( int i = 0; i < size; i++ ) {
			if ( i <= clear_stage + 1 ) {
				_button[ i ].SetActive( true );
 			} else {
				_button[ i ].SetActive( false );	
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
}
