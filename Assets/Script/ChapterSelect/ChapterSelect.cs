using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterSelect : Scene {
	private int _count;
	private int _next;
	private const int WAIT_COUNT = 10;
	private AudioSource _se;
	// Use this for initialization
	void Start () {
		_se = GetComponent< AudioSource >( );
		_next = -1;
	}
	
	// Update is called once per frame
	void Update ( ) {
		if ( _next >= 0 ) {
			_count++;
			if ( _count > WAIT_COUNT ) {
				setChapter( _next );
				SceneManager.LoadScene ("StageSelect");
			}
		}
	}

	public void setNext( int next ) {
		_se.Play( );
		_count = 0;
		_next = next;
	}
}
