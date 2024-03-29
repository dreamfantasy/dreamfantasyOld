﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour {
	public int _reverse_time;
	public Vector2 vec;
	private int _count;
	private bool _col;
	// Use this for initialization
	void Start () {
		_count = 0;
		Rigidbody2D rd = GetComponent< Rigidbody2D > ();
		rd.velocity = vec;
	}
	void Update () {
		_col = false;
		_count++;
		if (_count % _reverse_time == 0) {
			reverse( );
		}
	}
	void OnCollisionEnter2D(Collision2D collision) {
		if ( collision.collider.gameObject.tag != "Player" ) {
			if ( !_col ) {
				_col = true;
				reverse( );
			}
		}
	}

	void reverse( ) {
		_count = 0;
		vec *= -1;
		Rigidbody2D rd = GetComponent<Rigidbody2D>();
		rd.velocity = vec;
	}
}
