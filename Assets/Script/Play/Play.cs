using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour {
	//public GameObject _area;
	public enum STATE {
		WAIT,
		PLAY,
		GAME_CLEAR,
		GAME_OVER,
	};
	public Text _text_area;
	public GameObject _text_game_clear;
	public GameObject _text_game_over;
	public GameObject[ ] _stocks;
	private STATE _state = STATE.WAIT;
	private int _count = 0;
	private const int WAIT_TIME = 20;
	// Use this for initialization
	void Start ( ) {
		_text_area.text = "AREA 1/1";
	}


	
	// Update is called once per frame
	void Update ( ) {
		switch ( _state ) {
			case STATE.WAIT:
				_count++;
				if ( _count > WAIT_TIME ) {
					_state = STATE.PLAY;
					Destroy( _text_area );
				}
				break;
			case STATE.PLAY:
				break;
			case STATE.GAME_CLEAR:
			case STATE.GAME_OVER:
			if ( Device.getTouchPhase( ) == Device.PHASE.BEGAN ) {
				SceneManager.LoadScene( "Title" );
			}
			break;
		}
	}

	public void setState( STATE state ) {
		if ( state == STATE.GAME_CLEAR ) {
			_text_game_clear.SetActive( true );
		}
		if ( state == STATE.GAME_OVER ) {
			_text_game_over.SetActive( true );
		}
		_count = 0;
		_state = state;
	}

	public STATE getState( ) {
		return _state;
	}

	public void updateStockNum( int stock ) {
		for ( int i = stock; i < _stocks.Length; i++ ) {
			if ( i >= stock ) {
				_stocks[ i ].SetActive( false );
			}
		}
	}
}
