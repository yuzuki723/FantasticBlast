using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    //土魔法のPrefab
    [SerializeField, Tooltip("土魔法のPrefab")]
    private GameObject _MagicPrefab;

    //魔法の発射のオブジェクト
    [SerializeField, Tooltip("魔法の発射オブジェクト")]
    private GameObject _MagicShotObject;

    //魔法を生成する位置情報
    private Vector3 _instantiatePosition;

    //魔法の生成座標(読み取り専用)
    public Vector3 InstantiatePosition
    {
        get { return _instantiatePosition; }
    }

    ///<summary>
    ///着弾点の座標を持つコンポーネント
    ///</summary>
    private DrawMarker _drawMarker;

    [SerializeField] private GameObject _groundPrehab;

    ///<summary>
    ///発射オブジェクトの正面ベクトル(読み取り専用)
    ///</summary>
    public Vector3 GetTransformForward
    {
        get { return _MagicShotObject.transform.forward; }
    }

    private void Start()
    {
        _drawMarker = GetComponent<DrawMarker>();
    }

    private void Update()
    {
        // 弾の生成座標を更新
        _instantiatePosition = _MagicShotObject.transform.position;

        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
}
