using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterSelectButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void loadNextScene( ) {
		SceneManager.LoadScene ("StageSelect");
	}
}
