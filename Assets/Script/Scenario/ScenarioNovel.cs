using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioNovel : MonoBehaviour {
	[System.Serializable]
	public class Novel {
		public string name;
		public string text;
	}
	

	public Novel[ ] _novels;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Novel[ ] getNovel( ) {
		return _novels;
	}
}
