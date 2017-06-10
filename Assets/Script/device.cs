using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Device : MonoBehaviour {
	public enum PHASE {
		BEGAN,		//タッチした
		MOVED,		//タッチしている
		ENDED,		//指を離した
		CANCELED,	//タッチの追跡をやめた
		NONE		//なし
	};
	private static bool isTouchDevice( ) {
		return ( Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer );
	}
	public static Vector2 getPos( ) {
		Vector2 pos = Vector2.zero;
		if ( isTouchDevice( ) ) {
			pos = Input.GetTouch( 0 ).position;
		} else {
			pos = Input.mousePosition;
		}
		return pos;
	}


	public static PHASE getTouchPhase( ) {
		PHASE phase = PHASE.NONE;
		if ( isTouchDevice( ) ) {
			switch ( Input.GetTouch( 0 ).phase ) {
				case TouchPhase.Began:
					phase = PHASE.BEGAN;
					break;
				case TouchPhase.Moved:
					phase = PHASE.MOVED;
					break;
				case TouchPhase.Stationary:
					phase = PHASE.MOVED;
					break;
				case TouchPhase.Ended:
					phase = PHASE.ENDED;
					break;
				case TouchPhase.Canceled:
					phase = PHASE.CANCELED;
					break;
			}
		} else {
			if ( Input.GetMouseButton( 0 ) ) {
				phase = PHASE.MOVED;
			}
			if ( Input.GetMouseButtonDown( 0 ) ) {
				phase = PHASE.BEGAN;
			}
			if ( Input.GetMouseButtonUp( 0 ) ) {
				phase = PHASE.ENDED;
			}
		}
		return phase;
	}
}
