using UnityEngine;

public class Player : MonoBehaviour {
	enum ACTION {
		WAIT,
		NORMAL,
		MOVE,
		STRETCH,
		NONE,
	};
	enum STATE {
		FULL,
		CLAY,
		MAX
	};
	private Vector3 _start_pos;
	public float _move_range;	//タッチを離したときのボールの動かない範囲
	public float _move_speed;	//ボールが動くスピード
	public Play _play;
	public Sprite[ ] _sprite;
	private int _stock = 3;			//玉の個数
	private int _hp;			//壁に当たれる回数
	private ACTION _action = ACTION.WAIT;
	private Vector2 _touch_start_pos;//タッチを開始した位置
	private GameObject _allow;

	void Start( ) {
		_hp = _sprite.Length + 1;
		Transform trans = GetComponent< Transform >( );
		_allow = trans.Find( "Allow" ).gameObject;
		_allow.transform.localScale = Vector3.zero;
		_start_pos = trans.position;
	}
	

	void Update( ) {
		switch( _action ) {
			case ACTION.WAIT:
				if ( _play.getState( ) == Play.STATE.PLAY ) {
					_action = ACTION.NORMAL;
				}
				break;
			case ACTION.NORMAL:
				actOnNormal( );
				break;
			case ACTION.STRETCH:
				actOnStretch( );
				break;
			case ACTION.MOVE:
				actOnMove( );
				break;
		}
	}

	private void actOnStretch( ) {
		Vector2 vec = _touch_start_pos - Device.getPos( );
		if ( Device.getTouchPhase( ) == Device.PHASE.MOVED ) {//指を動かしている際の処理
			Vector2 size = Vector2.one * vec.magnitude * 0.1f;
			if ( size.magnitude > 4 ) {
				size = size.normalized * 4;
			}
			float angle = Vector2.Angle( Vector2.up + Vector2.left, vec );
			Vector3 axis = Vector3.Cross( Vector3.up + Vector3.left, vec );
			Quaternion rot = Quaternion.AngleAxis( angle, axis );
			_allow.transform.localScale = size;
			_allow.transform.localRotation = rot;
		}

		if ( Device.getTouchPhase( ) == Device.PHASE.ENDED ) {//指を離した際の処理
			_allow.transform.localScale = Vector3.zero;
			if ( vec.magnitude > _move_range ) {//指の位置が変わってた場合
				Rigidbody2D rd = GetComponent< Rigidbody2D >( );
				rd.velocity += vec.normalized * _move_speed;
				_action = ACTION.MOVE;
			} else {//指の位置が変わらなかった場合
				_action = ACTION.NORMAL;
			}
		}
	}

	private void actOnNormal( ) {
		if ( Device.getTouchPhase( ) == Device.PHASE.BEGAN ) {
			_touch_start_pos = Device.getPos( );
			_action = ACTION.STRETCH;
		}
	}
	private void actOnMove( ) {
	}


	void OnCollisionEnter2D( Collision2D collision ) {
		damage( );
	}

	void OnTriggerEnter2D( Collider2D other ) {
		//ゲームクリア
		Rigidbody2D rd = GetComponent< Rigidbody2D >( );
		rd.velocity = Vector2.zero;
		_play.setState( Play.STATE.GAME_CLEAR );
	}

	void damage( ) {
		_hp--;
		if ( _hp > 0 ) {
			SpriteRenderer sprite = GetComponent< SpriteRenderer >( );
			sprite.sprite = _sprite[ _hp - 1 ];
		}
		if ( _hp <= 0 ) {
			_stock--;
			reset( );
		}
		if ( _stock <= 0 ) {
			_play.setState( Play.STATE.GAME_OVER );
			Destroy( gameObject );
		}
	}

	public int getHp( ) {
		return _hp;
	}

	private void reset( ) {
		Rigidbody2D rd = GetComponent< Rigidbody2D >( );
		rd.velocity = Vector2.zero;
		Transform trans = GetComponent< Transform >( );
		trans.position = _start_pos;
		_hp = _sprite.Length;
		_play.updateStockNum( _stock );
		SpriteRenderer sprite = GetComponent< SpriteRenderer >( );
		sprite.sprite = _sprite[ _hp - 1 ];
		_action = ACTION.NORMAL;
	}
}
