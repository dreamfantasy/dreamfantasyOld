using UnityEngine;

public class Switch : MonoBehaviour {
	// Use this for initialization
	public GameObject _goal;

	void Start( ) {
		_goal.SetActive( false );
	}
	
	// Update is called once per frame
	void Update ( ) {
		
	}

	void OnTriggerEnter2D( Collider2D other ) {
		if ( other.tag != "Player" ) {
			return;
		}
		GetComponent< SpriteRenderer >( ).color = new Color( 1, 0, 0 );
		_goal.SetActive( true );
	}

	public void reset( ) {
		GetComponent< SpriteRenderer >( ).color = new Color( 1, 1, 1 );
		_goal.SetActive( false );
	}
}