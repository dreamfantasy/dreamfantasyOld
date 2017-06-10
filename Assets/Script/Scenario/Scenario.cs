using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

[System.Serializable]
public class Novel {
	public string scenario;
	public int chara_number;
}

public class Scenario : MonoBehaviour {
	public GameObject _chara0;
	public GameObject _chara1;
	public GameObject _parentObject;
	public Novel[ ] _novels;
	private int _line = 0;
	private List< GameObject > _chara0_list = new List< GameObject >( );
	private List< GameObject > _chara1_list = new List< GameObject >( );
	private const float INTARVAL = 54;
	// Use this for initialization
	void Start( ) {
		readText( );
	}
	
	// Update is called once per frame
	void Update( ) {
		if ( Device.getTouchPhase( ) == Device.PHASE.BEGAN ) {
			if ( _line < _novels.Length ) {
				readText( );
			} else {
				SceneManager.LoadScene( "Play" );
			}
		}
	}

	void readText( ) {
		for ( int i = 0; i < _chara0_list.Count; i++ ) {
			Vector3 pos = _chara0_list[ i ].transform.position;
			pos.y -= INTARVAL;
			if ( pos.y < 0 ) {
				_chara0_list[ i ].SetActive( false );
			}
			_chara0_list[ i ].transform.position = pos;
			//( pos, Quaternion.identity );
		}
		for ( int i = 0; i < _chara1_list.Count; i++ ) {
			Vector3 pos = _chara1_list[ i ].transform.position;
			pos.y -= INTARVAL;
			if ( pos.y < 0 ) {
				_chara1_list[ i ].SetActive( false );
			}
			_chara1_list[ i ].transform.position = pos;
				//SetPositionAndRotation( pos, Quaternion.identity );
		}

		if ( _novels[ _line ].chara_number == 0 ) {
			GameObject tmp = Instantiate( _chara0 );
			tmp.SetActive( true );
			tmp.transform.SetParent( _parentObject.transform, false );
			Text text = tmp.transform.Find( "Text" ).gameObject.GetComponent< Text >( );
			text.text = _novels[ _line ].scenario;
			_chara0_list.Add( tmp );
		} else {
			GameObject tmp = Instantiate( _chara1 );
			tmp.SetActive( true );
			tmp.transform.SetParent( _parentObject.transform, false );
			Text text = tmp.transform.Find( "Text" ).gameObject.GetComponent< Text >( );
			text.text = _novels[ _line ].scenario;
			_chara1_list.Add( tmp );
		}
		_line++;
	}

}
