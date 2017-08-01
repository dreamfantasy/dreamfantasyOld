using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour {
	//public GameObject _area;
	public enum STATE {
		WAIT,
		PLAY,
		STAGE_CLEAR,
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
	private int _area = 1;
	private const int MAX_AREA = 3;
	public Player _player;
	// Use this for initialization
	void Start ( ) {
		//エリア1をロード
		_area = 1;
		_text_area.text = "STAGE " + _area + "/3";
		SceneManager.LoadScene( "Stage_0_0_area" + ( _area - 1 ), LoadSceneMode.Additive );
	}


	
	// Update is called once per frame
	void Update ( ) {
		switch ( _state ) {
			case STATE.WAIT:
				_count++;
				if ( _count > WAIT_TIME ) {
					_state = STATE.PLAY;
					_text_area.text = "";
				}
				break;
			case STATE.PLAY:
				break;
			case STATE.STAGE_CLEAR:
				_area++;
				if ( _area <= MAX_AREA ) {
					setState( STATE.WAIT );
					_player.reset( );
					_text_area.text = "STAGE " + _area + "/3";
					SceneManager.UnloadSceneAsync( "Stage_0_0_area" + ( _area - 2 ) );
					SceneManager.LoadScene( "Stage_0_0_area" + ( _area - 1 ), LoadSceneMode.Additive );
				}
				if ( _area > MAX_AREA ) {
					setState( STATE.GAME_CLEAR );
				}
				break;
			case STATE.GAME_CLEAR:
				if ( Device.getTouchPhase( ) == Device.PHASE.BEGAN ) {
					SceneManager.LoadScene( "Result" );
				}
				break;
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
