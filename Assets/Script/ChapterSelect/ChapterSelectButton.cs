using UnityEngine;

public class ChapterSelectButton : MonoBehaviour {
	public ChapterSelect scene;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void loadNextScene( ) {
		scene.setNext( 0 );
	}
}
