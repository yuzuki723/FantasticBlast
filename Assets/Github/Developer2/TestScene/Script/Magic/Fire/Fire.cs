using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField,Tooltip("通常魔法のプレハブ")]
    GameObject _standerdPrefab;

    ///<summary>
    ///通常魔法の発射間隔
    ///</summary>
    private float _standerdInterval = 0.1f;

    ///<summary>
    ///通常魔法が発射されてどれだけ時間が経過したか記録
    ///</summary>
    private float _standerdTime = 0.0f;

    [SerializeField] GameObject _special;
    [SerializeField] float _specialSpeed = 600;

    //杖のアニメーター
    private Animator _cameAnimator;

    private GameObject _objct;

    private void Awake()
    {
        //杖のアニメーター取得
        _cameAnimator = GetComponentInChildren<Animator>().GetComponentInChildren<Animator>();
    }

    ///<summary>
    ///
    ///</summary>
    public void ShotFireMagic()
    {
        if (_objct != null)
        {
            _objct.transform.position = transform.GetChild(0).GetChild(0).transform.position;
            _objct.transform.rotation = transform.transform.rotation;
        }
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

        if(Input.GetMouseButtonDown(1))
        {
            //魔法発動時の杖の攻撃アニメーション再生
            _cameAnimator.SetBool("Attack", true);

            //特殊魔法発動
            ShotMagicSpecial();

        }


        //魔法を発動していない時はアニメーションさせない
        _cameAnimator.SetBool("Attack",false);
    }

    private void ShotMagicStanderd()
    {
        //角度調整
        Quaternion quaternion = transform.rotation;

        //出現位置
        Vector3 pos = transform.GetChild(0).GetChild(0).transform.position;

        //魔法が出現
        _objct = Instantiate(_standerdPrefab, pos,quaternion);
    }

    private void ShotMagicSpecial()
    {
        //出現位置
        Vector3 pos = transform.GetChild(0).GetChild(0).transform.position;

        //魔法が出現
        GameObject ball = (GameObject)Instantiate(_special, pos, Quaternion.identity);
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();

        //プレイヤーの正面に飛ばす
        ballRigidbody.AddForce(transform.forward * _specialSpeed);

    }
}
