using UnityEngine;

public class PopUpTutorial : MonoBehaviour {
	enum TUTORIAL {
		TUTORIAL_1,
		TUTORIAL_2,
		TUTORIAL_3,
		TUTORIAL_END,
	};
	public Sprite[ ] _sprite;
	private bool _active;
	private int _sprite_id;
	private TUTORIAL _tutorial;

	void Start( ) {
		_tutorial = TUTORIAL.TUTORIAL_1;
		_sprite_id = 0;
		GetComponent< SpriteRenderer >( ).sprite = _sprite[ _sprite_id ];
		_sprite_id++;
		_active = false;
		gameObject.SetActive( false );
	}
	

	void Update( ) {
		if ( !_active ) {
			return;
		}
		switch ( _tutorial ) {
			case TUTORIAL.TUTORIAL_1:
				if ( updatePhase1( ) ) {
					gameObject.SetActive( false );
					_active = false;
					_tutorial = TUTORIAL.TUTORIAL_2;
				}
				break;
			case TUTORIAL.TUTORIAL_2:
				if ( updatePhase2( ) ) {
					gameObject.SetActive( false );
					_active = false;
					_tutorial = TUTORIAL.TUTORIAL_3;
				}
				break;
			case TUTORIAL.TUTORIAL_3:
				if ( updatePhase3( ) ) {
					gameObject.SetActive( false );
					_active = false;
					_tutorial = TUTORIAL.TUTORIAL_END;
				}
				break;
		}
	}

	private bool updatePhase1( ) {
		bool end = false;
		if ( Device.getTouchPhase( ) == Device.PHASE.ENDED ) {
			if ( _sprite_id < 6 ) {
				GetComponent< SpriteRenderer >( ).sprite = _sprite[ _sprite_id ];
				_sprite_id++;
			} else {
				end = true;
			}
		}
		return end;
	}

	private bool updatePhase2( ) {
		bool end = false;
		if ( Device.getTouchPhase( ) == Device.PHASE.ENDED ) {
			if ( _sprite_id < 12 ) {
				GetComponent< SpriteRenderer >( ).sprite = _sprite[ _sprite_id ];
				_sprite_id++;
			} else {
				end = true;
			}
		}
		return end;
	}

	private bool updatePhase3( ) {
		bool end = false;
		if ( Device.getTouchPhase( ) == Device.PHASE.ENDED ) {
			if ( _sprite_id < 16 ) {
				GetComponent< SpriteRenderer >( ).sprite = _sprite[ _sprite_id ];
				_sprite_id++;
			} else {
				end = true;
			}
		}
		return end;
	}

	public void setActive( ) {
		_active = true;
		gameObject.SetActive( true );
		GetComponent< SpriteRenderer >( ).sprite = _sprite[ _sprite_id ];
	}

	public bool isActive( ) {
		return _active;
	}

	public void reset( ) {

		gameObject.SetActive( false );
		_active = false;
		switch ( _tutorial ) {
			case TUTORIAL.TUTORIAL_1:
				break;
			case TUTORIAL.TUTORIAL_2:
				_sprite_id = 0;
				_tutorial = TUTORIAL.TUTORIAL_1;
				break;
			case TUTORIAL.TUTORIAL_3:
				_sprite_id = 6;
				_tutorial = TUTORIAL.TUTORIAL_2;
				break;
			case TUTORIAL.TUTORIAL_END:
				_sprite_id = 12;
				_tutorial = TUTORIAL.TUTORIAL_2;
				break;
		}
		GetComponent< SpriteRenderer >( ).sprite = _sprite[ _sprite_id ];

	}
}
