using UnityEngine;

public class StageSelectButton : MonoBehaviour {
	private RectTransform _pos;
	public StageSelectCharacter _character;
	// Use this for initialization
	void Start( ) {
		_pos = GetComponent< RectTransform >( );
	}
	
	// Update is called once per frame
	void Update( ) {
	}

	public void select( int stage ) {
		_character.setTarget( _pos, stage );
	}
}
