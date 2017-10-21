using UnityEngine;

public class PlayerTutorial : Player {
	enum ACTION {
		WAIT,
		NORMAL,
		MOVE,
		STRETCH,
		TUTORIAL,
		NONE,
	};
	
	enum STATE {
		FULL,
		CLAY,
		MAX
	};

	
	private PopUpTutorial _pop_up;
	

	void Start( ) {
	}

	override protected void Awake ( ) {
		base.Awake( );
		GameObject playbase = GameObject.Find( "PlayBase" );
		_pop_up = playbase.transform.Find( "PopUp"  ).GetComponent< PopUpTutorial >( );
	}


	void Update( ) {
		if ( _pop_up.isActive( ) ) {
			return;
		}
		act( );
	}
	
	override protected void reset( ) {
		_pop_up.reset( );
		base.reset( );
	}

	
}
