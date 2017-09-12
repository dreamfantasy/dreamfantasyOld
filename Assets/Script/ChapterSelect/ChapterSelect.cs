using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterSelect : Scene {
	private int _count;
	private const int WAIT_COUNT = 10;
	private AudioSource _se;
	// Use this for initialization
	void Start( ) {
		_se = GetComponent< AudioSource >( );
		setChapter( -1 );
	}
	
	// Update is called once per frame
	void Update( ) {
		if ( getChapter( ) >= 0 ) {
			_count++;
			if ( _count > WAIT_COUNT ) {
				SceneManager.LoadScene( "StageSelect" + getChapter( ) );
			}
		}
	}

	public void select( int chapter ) {
		_se.Play( );
		_count = 0;
		setChapter( chapter );
	}
}
