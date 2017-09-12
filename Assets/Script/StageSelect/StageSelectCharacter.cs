using UnityEngine;
using UnityEngine.UI;

public class StageSelectCharacter : MonoBehaviour {
	//初期位置
	public RectTransform _target_pos;
	//プレイヤーの動く速度
	public float MOVE_SPEED;
	//Scene
	public StageSelect _stage_select;
	//自分の座標
	private RectTransform _pos;
	//SE
	private AudioSource _select_se;
	//選択中のステージ
	private int _selecting_stage;


	/*-----------------初期化処理-------------------*/
	void Start( ) {
		_pos = GetComponent< RectTransform >( );
		_pos.position = _target_pos.position;
		_select_se = GetComponent< AudioSource >( );
		_selecting_stage = 0;
	}
	
	/*-----------------ループ処理-------------------*/
	void Update( ) {
		if ( _target_pos ) {
			Vector2 distance = _target_pos.anchoredPosition - _pos.anchoredPosition;
			if ( distance.magnitude > MOVE_SPEED ) {
				_pos.anchoredPosition += distance.normalized * MOVE_SPEED;
			} else {
				_pos.position = _target_pos.position;
			}
		}
	}

	/*---------------以降メンバ関数-----------------*/
	
	public void setTarget( RectTransform pos, int stage ) {
		_select_se.Play( );
		//妖精がいるボタンと同じ場所を選択した場合は
		//シーン遷移
		if ( _selecting_stage == stage ) {
			_stage_select.selectStage( stage );
			return;
		}
		_selecting_stage = stage;
		_target_pos = pos;
	}
}
