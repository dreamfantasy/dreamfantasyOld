using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour {
	private static int _stock_num = 0;
	private static int _chapter = 0;
	private static int _stage = 0;
	private static int _clear_stage = -1;
	private static bool _tutorial = true;
	// Use this for initialization
	void Start ( ) {
	}
	
	// Update is called once per frame
	void Update ( ) {
	}

	public void setStockNum( int num ) {
		_stock_num = num;
	}

	public int getStockNum( ) {
		return _stock_num;
	}

	public void setStage( int num ) {
		_stage = num;
	}

	public int getStage( ) {
		return _stage;
	}

	public void setClearStage( int num ) {
		_clear_stage = num;
	}

	public int getClearStage( ) {
		return _clear_stage;
	}

	public void setChapter( int num ) {
		_chapter = num;
	}

	public int getChapter( ) {
		return 0;
	}
	
	public void setTutorial( bool value = false ) {
		_tutorial = value;
	}

	public bool isTutorial( ) {
		return _tutorial;
	}

}
