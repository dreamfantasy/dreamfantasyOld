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
		_goal.SetActive( true );
	}

	public void reset( ) {
		_goal.SetActive( false );
	}
}