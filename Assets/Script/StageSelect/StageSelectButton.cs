using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StageSelectButton : MonoBehaviour {
	private RectTransform _button;
	public StageSelectCharacter _character;
	// Use this for initialization
	void Start () {
		_button = GetComponent< RectTransform >( );
		_select_se = GetComponent< AudioSource >( );
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void OnClick( ) {
		_select_se.Play( );
		_character.setTarget( _button );
	}
}
