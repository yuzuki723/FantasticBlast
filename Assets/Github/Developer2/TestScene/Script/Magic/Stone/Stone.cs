using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    ///<summary>
    ///通常魔法のPrefab
    ///</summary>
    [SerializeField, Tooltip("通常魔法のPrefab")]
    private GameObject _standerdPrefab;

    ///<summary>
    ///通常魔法の速度
    ///</summary>
    [SerializeField, Tooltip("通常魔法の速度")]
    private float _standerdSpeed = 100;

    ///<summary>
    ///通常魔法の発射間隔
    ///</summary>
    private float _standerdInterval = 0.1f;

    ///<summary>
    ///通常魔法が発射されてどれだけ時間が経過したか記録
    ///</summary>
    private float _standerdTime = 0.0f;

    ///<summary>
    ///特殊魔法のPrefab
    ///</summary>
    [SerializeField, Tooltip("特殊魔法のPrefab")]
    private GameObject _specialPrefab;

    ///<summary>
    ///杖のアニメーター
    ///</summary>
    private Animator _cameAnimator;

    /// <summary>
    /// 着弾マーカーオブジェクトのPrefab
    /// </summary>
    [SerializeField, Tooltip("着弾マーカーオブジェクトのPrefab")]
    private GameObject _StonePointerPrefab;

    ///<summary>
    ///視線の先にマーカーを表示
    ///</summary>
    private DrawMarker _drawMarker;


    private void Awake()
    {
        //杖のアニメーター取得
        _cameAnimator = GetComponentInChildren<Animator>().GetComponentInChildren<Animator>();

        _drawMarker = GetComponent<DrawMarker>();
    }

    public void ShotStoneMagic()
    {
        if(Input.GetMouseButton(0) && _standerdTime <= 0.0f)
        {
            //魔法発動時の杖の攻撃アニメーション再生
            _cameAnimator.SetBool("Attack", true);

            //通常魔法発動
            ShotMagicStanderd();
            _standerdTime = _standerdInterval;

            return;
        }

        if(_standerdTime > 0.0f)
        {
            _standerdTime -=Time.deltaTime;
        }


        if (Input.GetMouseButton(1))
        {
            _drawMarker.Draw("_StonePointerPrefab",_StonePointerPrefab);
        }
        if(Input.GetMouseButtonUp(1))
        {
            //魔法発動時の杖の攻撃アニメーション再生
            _cameAnimator.SetBool("Attack", true);

            //特殊魔法発動
            ShotMagicSpecial();

            _drawMarker.Draw("_StonePointerPrefab",_StonePointerPrefab,false);

            return;
        }

        //魔法を発動していない時はアニメーションさせない
        _cameAnimator.SetBool("Attack",false);
    }

    private void ShotMagicStanderd()
    {
        //出現位置
        Vector3 pos = transform.GetChild(0).GetChild(0).transform.position;

        //魔法が出現
        GameObject magic = (GameObject)Instantiate(_standerdPrefab, pos, Random.rotation);
        Rigidbody rigidbody = magic.GetComponent<Rigidbody>();

        //プレイヤーの正面に飛ばす
        rigidbody.AddForce(transform.GetChild(0).GetChild(0).transform.forward * _standerdSpeed);

        Destroy(magic,1.0f);
    }

    private void ShotMagicSpecial()
    {
        //位置
        Vector3 startPos = _drawMarker.GetMakerPosition;
        startPos.y -= 2.0f;

        //岩を生成
        Instantiate(_specialPrefab,startPos,transform.rotation);

    }
}
