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
	public Sprite[ ] _sprite;

	private const double MOVE_SPEED = 7.0;
	private const double MAX_ALLOW_SIZE = 0.5;
	private const double ALLOW_SIZE_RATIO = 0.0013;
	private const double MOVE_RANGE = 60.0;	//タッチを離したときのボールの動かない範囲


	protected Play _play;
	protected int _hp;			//壁に当たれる回数
	protected bool _collision;	//1フレームに1度しかあたらないようにするための変数
	protected GameObject _allow;
	protected Vector2 _touch_start_pos;//タッチを開始した位置
	protected Vector2 _start_pos;
	protected AudioSource _ref_se;
	private ACTION _action;
	private LineRenderer _line;
	void Start( ) {
	}
	

	void Update( ) {
		act( );
	}

	virtual protected void Awake ( ) {
		{//オブジェクトを見つける
			GameObject playbase = GameObject.Find( "PlayBase" );
			_play   = playbase.transform.Find( "Script" ).GetComponent< Play >( );
		}
		Transform trans = GetComponent< Transform >( );
		_start_pos = trans.position;
		_allow = trans.Find( "Allow" ).gameObject;
		_allow.transform.localScale = Vector3.zero;
		_hp = _sprite.Length;
		_action = ACTION.WAIT;
		GetComponent< SpriteRenderer >( ).sprite = _sprite[ _hp - 1 ];
		_ref_se = GetComponent< AudioSource >( );
		
		//線
		_line = gameObject.AddComponent< LineRenderer >( );
		//マテリアル
		_line.material = new Material( Shader.Find("Unlit/Color") );
		_line.material.color = new Color( 1.0f, 0, 0, 0.2f );
		//線の幅
		_line.startWidth = 0.02f;
		_line.endWidth = 0.02f;
	}

	protected void act( ) {
		_collision = false;
		_line.positionCount = 0;

		switch( _action ) {
			case ACTION.WAIT:
				//強制待機
				if ( _play.getState( ) == Play.STATE.PLAY ) {
					setActionNormal( );
				}
				break;
			case ACTION.NORMAL:
				//入力待機
				actOnNormal( );
				break;
			case ACTION.STRETCH:
				//球を引っ張る
				actOnStretch( );
				break;
			case ACTION.MOVE:
				//自動移動
				break;
		}
	}

	virtual protected void setActionNormal( ) {
		_action = ACTION.NORMAL;
	}

	private void actOnStretch( ) {
		Vector2 vec = _touch_start_pos - Device.getPos( );

		if ( Device.getTouchPhase( ) == Device.PHASE.MOVED ) {
			//指を動かしているとき
			if ( vec.magnitude > MOVE_RANGE ) {
				//球が動く範囲の場合

				//矢印のサイズ計算
				Vector2 size = Vector2.one * vec.magnitude * ( float )ALLOW_SIZE_RATIO;
				if ( size.magnitude > MAX_ALLOW_SIZE ) {
					//矢印は一定以上の大きさにしない
					size = size.normalized * ( float )MAX_ALLOW_SIZE;
				}
				_allow.transform.localScale = size;

				//矢印の向きを計算( cross(外積)で回転方向、angleで角度を求めることによってrotを求める )
				float angle = Vector2.Angle( Vector2.up, vec );
				Vector3 axis = Vector3.Cross( Vector3.up, vec );
				Quaternion rot = Quaternion.AngleAxis( angle, axis );
				_allow.transform.localRotation = rot;

				//線描画
				_line.positionCount = 2;
				_line = gameObject.GetComponent< LineRenderer >( );
				Vector3 add1 = vec.normalized * 0.5f;
				Vector3 add2 = vec.normalized * 100.0f;
				Vector3 [ ] positions = {
					transform.position + add1,
					transform.position + add2
				};
				positions[ 0 ].z = -1.0f;
				positions[ 1 ].z = -1.0f;
				_line.SetPositions( positions );
			} else {
				//球が動かない範囲の場合

				//矢印非表示
				_allow.transform.localScale = Vector3.zero;
			}
		}

		if ( Device.getTouchPhase( ) == Device.PHASE.ENDED ) {
			//指を離したとき

			//矢印を見えなくする
			_allow.transform.localScale = Vector3.zero;

			if ( vec.magnitude > MOVE_RANGE ) {
				//指の位置が変わってた場合動かす
				Rigidbody2D rd = GetComponent< Rigidbody2D >( );
				rd.velocity += vec.normalized * ( float )MOVE_SPEED;
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

	void OnCollisionEnter2D( Collision2D collision ) {
		if ( _collision ||
			 _action == ACTION.WAIT ||
			 _action == ACTION.NORMAL ) {
			return;
		}
		_ref_se.Play( );
		damage( );
		_collision = true;
	}

	void OnTriggerEnter2D( Collider2D other ) {
		Goal goal = other.GetComponent< Goal >( );
		if ( !goal ) {
			return;
		}
		if ( goal.isTrans( ) ) {
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
			_play.deadPlayer( );
			if ( _play.getState( ) == Play.STATE.GAME_OVER ) {
				gameObject.SetActive( false );
			} else {
				reset( );
			}
		}
	}

	public int getHp( ) {
		return _hp;
	}

	virtual protected void reset( ) {
		_action = ACTION.WAIT;
		_hp = _sprite.Length;
		_play.resetSwicth( );
		GetComponent< Rigidbody2D	 >( ).velocity	= Vector2.zero;
		GetComponent< Transform		 >( ).position	= _start_pos;
		GetComponent< SpriteRenderer >( ).sprite	= _sprite[ _hp - 1 ];
	}

	
}
