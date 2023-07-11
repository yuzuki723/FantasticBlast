using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Standard : Magic
{
    //回転
    [SerializeField] float _rotateX;
    [SerializeField] float _rotateY;
    [SerializeField] float _rotateZ;

    /// <summary>
    /// 破片クラス呼び出し用
    /// </summary>
    private Fragment _fragment;

    [SerializeField,Tooltip("破片のステータス")]
    SetFragmentStatus _fragmentStatus = new SetFragmentStatus();
    [System.Serializable]
    public class SetFragmentStatus
    {
        /// <summary>
        /// 破壊時の破片プレハブ
        /// </summary>
        public GameObject Prefab;

        /// <summary>
        /// 飛び散る破片の数
        /// </summary>
        public float Number;

        /// <summary>
        /// 飛び散る破片の速さ
        /// </summary>
        public float Speed;

        /// <summary>
        /// 飛び散る破片が消える時間
        /// </summary>
        public float DestroyTime;
    }

    private void Start()
    {
        //何も衝突せず、3秒が経過したらその場で消滅する
        Destroy(gameObject,3);
    }

    void Update()
    {
        //常に回転し続ける
        Rotate();
    }

    ///<summary>
    ///回転
    ///</summary>
    private void Rotate()
    {
        gameObject.transform.Rotate(new Vector3(_rotateX,_rotateY,_rotateZ)* Time.deltaTime);
    }

    ///<summary>
    ///何かのオブジェクトに衝突したら呼び出し
    ///</summary>
    ///<param name="other">衝突した相手</param>
    private void OnCollisionEnter(Collision other)
    {
        //魔法を消去する
        Destroy(gameObject);
    }

    ///<summary>
    ///オブジェクトが消滅したら呼び出し
    ///</summary>
    private void OnDestroy()
    {
        //破片のステータスを加える
        _fragment = GetComponent<Fragment>();
        _fragment.SetFragmentStatus(_fragmentStatus.Prefab,_fragmentStatus.Number,_fragmentStatus.Speed,_fragmentStatus.DestroyTime);

        //魔法の消滅を分かりやすくするため消滅した座標から破片が飛び散る
        _fragment.FlyAroundFragment();
    }

}
