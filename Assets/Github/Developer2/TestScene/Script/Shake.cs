using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    /// <summary>
    /// 初期位置
    /// </summary>
    private Vector3 _initPosition;

    /// <summary>
    /// ランダムで出力された座標を保存する変数
    /// </summary>
    private Vector3 _randomPosition;

    /// <summary>
    /// 揺らす時間
    /// </summary>
    private float _shakeTime = 3;

    /// <summary>
    /// 揺らす力
    /// </summary>
    private float _shakePower = 5;

    /// <summary>
    /// 揺らすかどうか
    /// </summary>
    private bool _isShake = false;

    /// <summary>
    /// 何回揺らしたか
    /// </summary>
    private int _shakeCount;

    private void Update()
    {
        // 許可がない場合は実行しない
        if (!_isShake) return;

        // 時間が0になったら終了
        _shakeTime -= Time.deltaTime;
        if (_shakeTime > 0)
        {
            // オブジェクトが振動関係なく移動したかを確認
            Vector3 beforePos = Vector3.zero;
            beforePos = transform.position - _randomPosition;
            if (transform.position != beforePos)
            {
                // 移動していたら初期位置を更新
                _initPosition = beforePos;
            }

            // カウントが偶数の時は位置を変更・奇数の時は初期位置に戻す
            Vector3 randomPos = Vector3.zero;
            if (_shakeCount % 2 == 0)
            {
                _randomPosition.x = Random.Range(-_shakePower,_shakePower);
                _randomPosition.y = Random.Range(-_shakePower,_shakePower);
                _randomPosition.z = Random.Range(-_shakePower,_shakePower);
            }
            else
            {
                transform.position = _initPosition;
            }

            // ランダムで出力された値を座標に加える
            transform.position += _randomPosition;
            _shakeCount++;
        }
        else
        {
            // 終了したらパラメータをリセット
            ResetParameter();
        }
    }

    /// <summary>
    /// 揺れを開始する
    /// </summary>
    /// <param name="initPosition">初期位置</param>
    /// <param name="time">揺らす時間</param>
    /// <param name="power">揺らす力</param>
    public void StartShake(Vector3 initPosition, float time, float power)
    {
        //パラメータセット
        _isShake = true;
        _shakeTime = time;
        _shakePower = ClampPower(power);

        //初期位置を記憶
        _initPosition = initPosition;
    }

    /// <summary>
    /// パラメータをリセットする
    /// </summary>
    private void ResetParameter()
    {
        _isShake = false;
        _shakeTime = 0;
        _shakePower = 0;
        _initPosition = Vector3.zero;
    }

    /// <summary>
    /// 揺れの力の数値を調整する(Max:100 Min:1)
    /// </summary>
    /// <param name="power">揺らす力</param>
    /// <returns>調整済みのpower</returns>
    private float ClampPower(float power)
    {
        //そのままの値だと大きすぎるので500で割る
        return Mathf.Clamp(power,1,100) / 500;
    }


}


