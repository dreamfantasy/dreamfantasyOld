using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
	private bool _trans;
	private float _alpha_speed;
	private int _hp;
	private int _max_hp;
	// Use this for initialization
	protected void Start ( ) {
		_max_hp = 1;
		_hp = 1;
		_trans = false;
	}
	
	// Update is called once per frame
	 protected void Update () {
		if ( _trans ) {
			SpriteRenderer sprite = GetComponent< SpriteRenderer >( );
			if ( sprite.color.a > 0.4 ) {
				_alpha_speed *= -1;
			}
			if ( sprite.color.a < 0.3 ) {
				_alpha_speed *= -1;
			}

			float alpha = sprite.color.a;
			alpha += _alpha_speed;
			sprite.color = new Color( 1, 1, 1, alpha );
		}
		
	}

	public void setTrans( bool trans ) {
		if ( trans ) {
			_hp = _max_hp;
		} else {
			_hp--;
			if ( _hp > 0 ) {
				return;
			}
		}
		if ( trans ) {
			GetComponent< SpriteRenderer >( ).color = new Color( 1, 1, 1, 0.3f );
			_alpha_speed = 0.003f;
		} else {
			GetComponent< SpriteRenderer >( ).color = new Color( 1, 1, 1, 1 );
		}

		_trans = trans;
	}

	public bool isTrans( ) {
		return _trans;
	}

	protected void setHp( int hp ) {
		if ( _max_hp < hp ) {
			_max_hp = hp;
		}
		_hp = hp;
	}
}
