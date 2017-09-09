using UnityEngine;

public class Switch : MonoBehaviour {
	// Use this for initialization
	public GameObject _goal;
	void Start( ) {
		_goal.GetComponent< Goal >( ).setTrans( true );
	}
	
	// Update is called once per frame
	void Update ( ) {
	}

	void OnTriggerEnter2D( Collider2D other ) {
		if ( other.tag != "Player" ) {
			return;
		}
		GetComponent< SpriteRenderer >( ).color = new Color( 1, 0, 0 );
		_goal.GetComponent< Goal >( ).setTrans( false );
	}

	public void reset( ) {
		GetComponent< SpriteRenderer >( ).color = new Color( 1, 1, 1 );
		_goal.GetComponent< Goal >( ).setTrans( true );
	}
}