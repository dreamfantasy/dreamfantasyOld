using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
	private bool _trans;
	private float _alpha_speed;
	// Use this for initialization
	void Start ( ) {
		_trans = false;
	}
	
	// Update is called once per frame
	void Update () {
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
}
