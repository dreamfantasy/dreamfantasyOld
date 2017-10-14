using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play : Scene {
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
	public GameObject[ ] _board;
	public AudioSource _bgm;
	public AudioSource _goal_sound;

	private const int MAX_STAGE = 3;
	private const int WAIT_TIME = 30;
	private const int MAX_STOCK = 3;

	private int _count;
	private int _stage;
	private STATE _state;


	void Start ( ) {
		//エリア1をロード
		_stage = 0;
		_count = 0;
		_state = STATE.WAIT;
		setAreaText( );
		setStockNum( MAX_STOCK );
		updateStockNum( );
		_board[ 0 ].SetActive( true );
		_board[ 1 ].SetActive( false );
		_board[ 2 ].SetActive( false );
		
		_bgm.Play( );
	}

	
	void Update ( ) {
		switch ( _state ) {
			case STATE.WAIT:
				//一定時間エリア表示
				_count++;
				if ( _count > WAIT_TIME ) {
					if ( Device.getTouchPhase( ) == Device.PHASE.ENDED ) {
						_state = STATE.PLAY;
						_text_area.text = "";
					}
				}
				break;
			case STATE.PLAY:
				break;
			case STATE.STAGE_CLEAR:
				if ( !setNextStage( ) ) {
					setState( STATE.GAME_CLEAR );
				}
				break;
			case STATE.GAME_CLEAR:
				if ( Device.getTouchPhase( ) == Device.PHASE.ENDED ) {
					if ( getStage( ) >= getClearStage( ) ) {
						setClearStage( getClearStage( ) + 1 );
					}
					if ( isTutorial( ) ) {
						setTutorial( false );
					}
					SceneManager.LoadScene( "StageSelect0" );
					//SceneManager.LoadScene( "Result" );
				}
				break;
			case STATE.GAME_OVER:
				if ( Device.getTouchPhase( ) == Device.PHASE.ENDED ) {
					if ( isTutorial( ) ) {
						SceneManager.LoadScene ( "TitleTutorial" );
					} else {
						SceneManager.LoadScene( "StageSelect" + getChapter( ) );
					}
				}
				break;
		}

		if ( !_bgm.isPlaying ) {
			_bgm.Play( );
		}
	}

	public void setState( STATE state ) {
		if ( state == STATE.GAME_CLEAR ) {
			_goal_sound.Play( );
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

	public void updateStockNum( ) {
		int size = _stocks.Length - getStockNum( );
		for ( int i = 0; i < size; i++ ) {
			int idx = i + getStockNum( );
			_stocks[ idx ].SetActive( false );
		}
	}

	private void setAreaText( ) {
		_text_area.text = "STAGE " + ( _stage + 1 ) + "/3";
	}

	private bool setNextStage( ) {
		bool result = false;
		_stage++;
		if ( _stage < MAX_STAGE ) {
			setState( STATE.WAIT );
			setAreaText( );
			_board[ _stage - 1 ].SetActive( false );
			_board[ _stage ].SetActive( true );
			result = true;
		}
		return result;
	}

	public void resetSwicth( ) {
		GameObject[ ] swiths = GameObject.FindGameObjectsWithTag( "Switch" );
		int size = swiths.Length;
		for ( int i = 0; i < size; i++ ) {
			swiths[ i ].GetComponent< Switch >( ).reset( );
		}
	}

	public void retire( ) {	
		if ( isTutorial( ) ) {
			SceneManager.LoadScene( "TitleTutorial" );
		}
		SceneManager.LoadScene( "StageSelect" + getChapter( ) );
	}

	public void deadPlayer( ) {
		int stock = getStockNum( ) - 1;
		if ( stock < 0 ) {
			stock = 0;
			setState( STATE.GAME_OVER );
		}
		setStockNum( stock );
		
		updateStockNum( );
	}
}
