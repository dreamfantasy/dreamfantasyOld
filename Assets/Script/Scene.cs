using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour {
	private static int _stock_num = 0;
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
}
