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
	public Play _play;
	public Sprite[ ] _sprite;

	private const int MOVE_RANGE = 10;	//タッチを離したときのボールの動かない範囲
	private const int INIT_STOCK = 3;
	private const int MOVE_SPEED = 5;
	private const int MAX_ALLOW_SIZE = 5;

	private int _stock;			//玉の個数
	private int _hp;			//壁に当たれる回数
	private bool _collision;	//1フレームに1度しかあたらないようにするための変数
	private GameObject _allow;
	private Vector2 _touch_start_pos;//タッチを開始した位置
	private Vector2 _start_pos;
	private ACTION _action;

	void Start( ) {
		Transform trans = GetComponent< Transform >( );
		_start_pos = trans.position;
		_allow = trans.Find( "Allow" ).gameObject;
		_allow.transform.localScale = Vector3.zero;
		_stock = INIT_STOCK;
		_hp = _sprite.Length;
		_action = ACTION.WAIT;
		GetComponent< SpriteRenderer >( ).sprite = _sprite[ _hp - 1 ];
	}
	

	void Update( ) {
		_collision = false;
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

		if ( Device.getTouchPhase( ) == Device.PHASE.MOVED ) {
			//指を動かしているとき

			//矢印の大きさを計算
			Vector2 size = Vector2.one * vec.magnitude * 0.1f;
			if ( size.magnitude > MAX_ALLOW_SIZE ) {
				//矢印は一定以上の大きさにしない
				size = size.normalized * MAX_ALLOW_SIZE;
			}
			_allow.transform.localScale = size;

			//矢印の向きを計算( cross(外積)で回転方向、angleで角度を求めることによってrotを求める )
			float angle = Vector2.Angle( Vector2.up + Vector2.left, vec );
			Vector3 axis = Vector3.Cross( Vector3.up + Vector3.left, vec );
			Quaternion rot = Quaternion.AngleAxis( angle, axis );
			_allow.transform.localRotation = rot;
		}

		if ( Device.getTouchPhase( ) == Device.PHASE.ENDED ) {
			//指を離したとき

			//矢印を見えなくする
			_allow.transform.localScale = Vector3.zero;

			if ( vec.magnitude > MOVE_RANGE ) {
				//指の位置が変わってた場合動かす
				Rigidbody2D rd = GetComponent< Rigidbody2D >( );
				rd.velocity += vec.normalized * MOVE_SPEED;
				_action = ACTION.MOVE;
			} else {
				//指の位置が変わらなかった場合待機状態へ戻る
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
		if ( _collision ) {
			return;
		}
		damage( );
		_collision = true;
	}

	void OnTriggerEnter2D( Collider2D other ) {
		if ( other.tag !=  "Goal" ) {
			return;
		}
		//ゲームクリア
		Rigidbody2D rd = GetComponent< Rigidbody2D >( );
		rd.velocity = Vector2.zero;
		_play.setState( Play.STATE.STAGE_CLEAR );
	}

	private void damage( ) {
		_hp--;
		if ( _hp > 0 ) {
			SpriteRenderer sprite = GetComponent< SpriteRenderer >( );
			sprite.sprite = _sprite[ _hp - 1 ];
		} else {
			_stock--;
			if ( _stock < 0 ) {
				_play.setState( Play.STATE.GAME_OVER );
				gameObject.SetActive( false );
			} else {
				reset( );
			}
		}
	}

	public int getHp( ) {
		return _hp;
	}

	public void reset( ) {
		_action = ACTION.WAIT;
		_hp = _sprite.Length;
		_play.updateStockNum( _stock );
		_play.resetSwicth( );
		GetComponent< Rigidbody2D	 >( ).velocity	= Vector2.zero;
		GetComponent< Transform		 >( ).position	= _start_pos;
		GetComponent< SpriteRenderer >( ).sprite	= _sprite[ _hp - 1 ];
	}

	
}
