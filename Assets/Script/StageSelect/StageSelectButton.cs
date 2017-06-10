using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StageSelectButton : MonoBehaviour {
	private RectTransform _button;
	public StageSelectCharacter _character;
	// Use this for initialization
	void Start () {
		_button = GetComponent< RectTransform >( );
	}
	
	// Update is called once per frame
	void Update () {
		if( Device.getTouchPhase( ) == Device.PHASE.BEGAN )
		{
			// Check if the mouse was clicked over a UI element
			if(!EventSystem.current.IsPointerOverGameObject())
			{
				OnClick( );
			}
		}
	}

	public void OnClick( ) {
		_character.setTarget( _button );
	}
}
