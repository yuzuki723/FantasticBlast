using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DrawMarker : MonoBehaviour
{
    /// <summary>
    /// 魔法として出現するPrefab
    /// </summary>
    [SerializeField, Tooltip("魔法として出現するPrefab")]
    private GameObject _MagicShotPrefab;

    /// <summary>
    /// マーカーのオブジェクト
    /// </summary>
    private GameObject _makerObject;

    /// <summary>
    /// マーカーを識別するための変数
    /// </summary>
    private string _makerName;

    /// <summary>
    /// マーカーを表示する座標
    /// </summary>
    private Vector3 _makerPosition;

    /// <summary>
    /// マーカーを表示できる上限距離
    /// </summary>
    [SerializeField, Tooltip("マーカーを表示できる上限距離")]
    private float _makerMaxDistance;

    /// <summary>
    /// マーカーの座標読み取り
    /// </summary>
    public Vector3 GetMakerPosition
    {
        get { return _makerPosition; }
    }

    private bool _isPlacement;

    public bool IsPlacement
    {
        get { return _isPlacement; }
    }

    private void Awake()
    {
        _makerObject   = null;
        _makerName     = string.Empty;
        _makerPosition = Vector3.zero;
        _isPlacement = false;
    }

    /// <summary>
    /// 目線の先にマーカーを表示する
    /// </summary>
    /// <param name="makerName">マーカーを識別するための名前</param>
    /// <param name="makerPrefab">マーカーのプレハブ</param>
    /// <param name="flg">マーカーを表示するかどうか</param>
    public void Draw(string makerName,GameObject makerPrefab,bool flg = true)
    {
        // falseならマーカーを非表示にする
        if (flg != true)
        {
            _makerObject.SetActive(flg);
            return;
        }

        // 現在保存しているnameと比較して違っていたら表示するプレハブを変更する
        if (makerName != _makerName)
        {
            // 今後表示するプレハブのnameを記憶する
            _makerName = makerName;

            // プレハブをインスタンス
            _makerObject = Instantiate(makerPrefab,Vector3.zero,Quaternion.identity);
        }

        // マーカーの回転をプレイヤーと同じにする(常に正面を向く)
        _makerObject.transform.rotation = transform.rotation;

        // 目線に向かってレイを飛ばし、設定値より距離が短ければマーカーを表示する
        RaycastHit hitInfo;
        Physics.Raycast(_MagicShotPrefab.transform.position, _MagicShotPrefab.transform.forward, out hitInfo);
        if (hitInfo.distance <= _makerMaxDistance)
        {
            // 着弾点の座標を求める
            _makerPosition = CalculateImpactPosition(hitInfo.distance);

            // マーカーを表示する
            _isPlacement = true;
        }
        else
        {
            // 設定値より遠いなら表示しない
            _isPlacement = false;
        }

        if (IsGroundFlat() != true)
        {
            _isPlacement = false;
        }
        ShowPointer(_makerPosition, _isPlacement);
    }

    /// <summary>
    /// 指定された座標にマーカーを表示
    /// </summary>
    /// <param name="position">マーカーを表示する座標</param>
    /// <param name="flg">マーカーを表示するかどうか</param>
    private void ShowPointer(Vector3 position, bool flg)
    {
        _makerObject.transform.position = position;
        _makerObject.gameObject.SetActive(flg);
    }

    /// <summary>
    /// 着弾点の座標を求める
    /// </summary>
    /// <param name="distance">着弾点までの距離</param>
    /// <returns>着弾点の座標</returns>
    private Vector3 CalculateImpactPosition(float distance)
    {
        return _MagicShotPrefab.transform.position + _MagicShotPrefab.transform.forward * distance;
    }

    private bool IsGroundFlat()
    {
        Vector3[] checkPos = { new Vector3(1, 0, 0), new Vector3(-1, 0, 0), new Vector3(0, 0, 1), new Vector3(0, 0, -1) };
        for (int i = 0; i < 4; i++)
        {
            RaycastHit hit;
            Physics.Raycast(_makerObject.transform.position + checkPos[i], new Vector3(0, -1, 0), out hit);
            hit.GetType();
            if (hit.distance >= 1)
            {
                return false;
            }
        }
        return true;
    }
}
