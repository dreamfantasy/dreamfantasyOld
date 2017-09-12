using UnityEngine;

public class ChapterSelectButton : MonoBehaviour {
	public ChapterSelect _chapter_select;

	// Use this for initialization
	void Start( ) {
	}
	
	// Update is called once per frame
	void Update( ) {
	}

	public void select( int chapter ) {
		_chapter_select.select( chapter );
	}
}
