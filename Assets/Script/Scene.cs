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

	protected void setStockNum( int num ) {
		_stock_num = num;
	}

	public int getStockNum( ) {
		return _stock_num;
	}

	protected void setStage( int num ) {
		_stage = num;
	}

	public int getStage( ) {
		return _stage;
	}

	protected void setClearStage( int num ) {
		_clear_stage = num;
	}

	public static int getClearStage( ) {
		return _clear_stage;
	}

	protected void setChapter( int num ) {
		_chapter = 0;
	}

	public int getChapter( ) {
		return _chapter;
	}
	
	protected void setTutorial( bool value ) {
		_tutorial = value;
	}

	public bool isTutorial( ) {
		return _tutorial;
	}

}
