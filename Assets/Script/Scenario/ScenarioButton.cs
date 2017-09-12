using UnityEngine;

public class ScenarioButton : MonoBehaviour {
	public Scenario _scenario;
	// Use this for initialization
	void Start( ) {
	}
	
	// Update is called once per frame
	void Update( ) {
	}

	
	public void skip( ) {
		_scenario.loadScenePlay( );
	}
}
