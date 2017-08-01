using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {
	// Use this for initialization
	public GameObject _goal;
	private GameObject _switch;
	void Start( ) {
		_goal.SetActive( false );
		_switch = GetComponent< GameObject >( );
	}
	
	// Update is called once per frame
	void Update ( ) {
		
	}

	void OnCollisionEnter2D( Collision2D collision ) {
		if ( collision.gameObject.tag != "Player" ) {
			return;
		}
		_goal.SetActive( true );
	}
}
