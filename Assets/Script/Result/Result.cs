using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Result : Scene {
	public GameObject _stock_text;

	// Use this for initialization
	void Start ( ) {
		_stock_text.GetComponent< Text >( ).text = "残り玉数 " + getStockNum( );
	}
	
	// Update is called once per frame
	void Update ( ) {
		if ( Device.getTouchPhase( ) == Device.PHASE.ENDED ) {
			SceneManager.LoadScene( "StageSelect" );
		}
	}
}
