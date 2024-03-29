﻿using UnityEngine;

public class Switch : MonoBehaviour {
	// Use this for initialization
	private GameObject _goal;
	private bool _enable;
	void Start( ) {
		_enable = true;
		_goal = GameObject.Find( "Goal" );
		_goal.GetComponent< Goal >( ).setTrans( true );
	}
	
	// Update is called once per frame
	void Update ( ) {
	}

	void OnTriggerEnter2D( Collider2D other ) {
		if ( other.tag != "Player" ) {
			return;
		}
		if ( !_enable ) {
			return;
		}
		_enable = false;
		GetComponent< SpriteRenderer >( ).color = new Color( 1, 0.4f, 0.4f );
		_goal.GetComponent< Goal >( ).setTrans( false );
	}

	public void reset( ) {
		_enable = true;
		GetComponent< SpriteRenderer >( ).color = new Color( 1, 1, 1 );
		_goal.GetComponent< Goal >( ).setTrans( true );
	}
}