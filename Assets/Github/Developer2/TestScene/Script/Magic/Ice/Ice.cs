using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    [SerializeField] GameObject _standerd;
    [SerializeField] float _standerdSpeed = 100;

    [SerializeField] GameObject _special;

    //杖のアニメーター
    private Animator _cameAnimator;

    /// <summary>
    /// 着弾マーカーオブジェクトのPrefab
    /// </summary>
    [SerializeField, Tooltip("着弾マーカーオブジェクトのPrefab")]
    private GameObject _IcePointerPrefab;

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

    public void ShotIceMagic()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //魔法発動時の杖の攻撃アニメーション再生
            _cameAnimator.SetBool("Attack", true);

            //通常魔法発動
            ShotMagicStanderd();
            return;
        }

        if (Input.GetMouseButton(1))
        {

            _drawMarker.Draw("_IcePointerPrefab",_IcePointerPrefab);
        }
        if(Input.GetMouseButtonUp(1))
        {
            //魔法発動時の杖の攻撃アニメーション再生
            _cameAnimator.SetBool("Attack", true);

            //特殊魔法発動
            ShotMagicSpecial();

            _drawMarker.Draw("_IcePointerPrefab",_IcePointerPrefab,false);
            
            return;
        }

        //魔法を発動していない時はアニメーションさせない
        _cameAnimator.SetBool("Attack",false);
    }

    private void ShotMagicStanderd()
    {
        Quaternion quaternion = transform.rotation * Quaternion.Euler(0, -90, 0);

        //出現位置
        Vector3 pos = transform.GetChild(0).GetChild(0).transform.position;

        //魔法が出現
        GameObject magic = (GameObject)Instantiate(_standerd, pos, quaternion);
        Rigidbody rigidbody = magic.GetComponent<Rigidbody>();

        //プレイヤーの正面に飛ばす
        rigidbody.AddForce(transform.GetChild(0).GetChild(0).transform.forward * _standerdSpeed,ForceMode.Acceleration);
    }

    private void ShotMagicSpecial()
    {
        //出現位置
        Vector3 pos = _drawMarker.GetMakerPosition;
        pos.y += 2;

        //魔法が出現
        GameObject magic = Instantiate(_special, pos, transform.rotation);

    }

}
