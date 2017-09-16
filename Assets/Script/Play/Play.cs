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
	public Switch[ ] _switch;
	public AudioSource _bgm;
	public AudioSource _goal_sound;

	private const int MAX_STAGE = 3;
	private const int WAIT_TIME = 20;

	private int _count;
	private int _stage;
	private STATE _state;


	void Start ( ) {
		//エリア1をロード
		_stage = 0;
		_count = 0;
		_state = STATE.WAIT;
		setAreaText( );

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
					_state = STATE.PLAY;
					_text_area.text = "";
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
				if ( Device.getTouchPhase( ) == Device.PHASE.BEGAN ) {
					if ( getStage( ) > getClearStage( ) ) {
						setClearStage( getClearStage( ) );
					}
					SceneManager.LoadScene( "Result" );
				}
				break;
			case STATE.GAME_OVER:
				if ( Device.getTouchPhase( ) == Device.PHASE.BEGAN ) {
					SceneManager.LoadScene( "Title" );
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
		int switch_size = _switch.Length;
		for ( int i = 0; i < switch_size; i++ ) {
			_switch[ i ].reset( );
		}
	}

	public void retire( ) {	
		if ( isTutorial( ) ) {
			SceneManager.LoadScene( "TitleTutorial" + getChapter( ) );
		}
		SceneManager.LoadScene( "StageSelect" + getChapter( ) );
	}
}
