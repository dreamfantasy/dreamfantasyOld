using UnityEngine;
using UnityEngine.UI;

public class StageSelectCharacter : MonoBehaviour {
	private RectTransform _pos;
	public RectTransform _target;
	public float MOVE_SPEED;
	public StageSelect _stage_select;
	private AudioSource _select_se;
	// Use this for initialization
	void Start () {
		_pos = GetComponent< RectTransform >( );
		_select_se = GetComponent< AudioSource >( );
	}
	
	// Update is called once per frame
	void Update () {
		if ( _target ) {
			Vector2 distance = _target.anchoredPosition - _pos.anchoredPosition;
			if ( distance.magnitude > MOVE_SPEED ) {
				_pos.anchoredPosition += distance.normalized * MOVE_SPEED;
			} else {
				_pos.position = _target.position;
			}
		}
	}

	public void setTarget( RectTransform target ) {
		bool set = false;
		if ( target.tag == _target.tag ) {
			int stage = 2;
			switch ( _target.tag ) {
			case "Stage1":
				stage = 0;
				break;
			case "Stage1-1":
				stage = 1;
				break;
			case "Stage1-1-1":
			case "Stage1-1-2":
			case "Stage1-1-1-1":
			case "Stage1-1-1-2":
				stage = 2;
				break;
		}
			_stage_select.setNext( stage );
		}

		switch ( _target.tag ) {
			case "Stage1":
				if ( target.tag == "Stage1-1" ) {
					set = true;
				}
				break;
			case "Stage1-1":
				if ( target.tag == "Stage1" ||
					 target.tag == "Stage1-1-1" ||
					 target.tag == "Stage1-1-2" ) {
					set = true;
				}
				break;
			case "Stage1-1-1":
				if ( target.tag == "Stage1-1" ||
					 target.tag == "Stage1-1-1-1" ||
					 target.tag == "Stage1-1-1-2" ) {
					set = true;
				}
				break;
			case "Stage1-1-2":
				if ( target.tag == "Stage1-1" ) {
					set = true;
				}
				break;
			case "Stage1-1-1-1":
				if ( target.tag == "Stage1-1-1" ) {
					set = true;
				}
				break;
			case "Stage1-1-1-2":
				if ( target.tag == "Stage1-1-1" ) {
					set = true;
				}
				break;
		}
		if ( set ) {
			_select_se.Play( );
			_target = target;
		}
	}
}
