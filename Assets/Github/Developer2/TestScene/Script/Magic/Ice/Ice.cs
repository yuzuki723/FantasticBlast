using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 氷魔法クラス
/// </summary>
public class Ice : MonoBehaviour
{
    [SerializeField, Tooltip("通常魔法のステータス")]
    private StandardStatus _standardStatus = new StandardStatus();
    [System.Serializable]
    public class StandardStatus
    {
        [SerializeField, Tooltip("通常魔法のPrefab")]
        public GameObject Prefab;

        [SerializeField, Tooltip("通常魔法の速度")]
        public float Speed = 3000;

        [SerializeField, Tooltip("通常魔法が消滅するまでの時間")]
        public float DestoryTime = 3.0f;
    }

    [SerializeField, Tooltip("通常魔法のステータス")]
    private SpecialStatus _specialStatus = new SpecialStatus();
    [System.Serializable]
    public class SpecialStatus
    {
        [SerializeField, Tooltip("特殊魔法のPrefab")]
        public GameObject Prefab;

        [SerializeField, Tooltip("マーカーのPrefab")]
        public GameObject MakerPrefab;
    }

    // 杖のアニメーター
    private Animator _cameAnimator;

    /// <summary>
    /// 視線の先にマーカーを表示
    /// </summary>
    private DrawMarker _drawMarker;

    private void Awake()
    {
        // 杖のアニメーター取得
        _cameAnimator = GetComponentInChildren<Animator>().GetComponentInChildren<Animator>();

        _drawMarker = GetComponent<DrawMarker>();
    }

    /// <summary>
    /// 氷魔法実行
    /// </summary>
    public void ShotIceMagic()
    {
        // 左クリックするたびに魔法を実行
        ShotMagicStandard();

        // 右クリックを長押しで魔法を設置する場所を決めて、離すと魔法が設置される
        ShotMagicSpecial();

        // 魔法を発動していない時はアニメーションさせない
        //_cameAnimator.SetBool("Attack",false);
    }

    /// <summary>
    /// 通常魔法の処理
    /// </summary>
    private void ShotMagicStandard()
    {
        // 左クリックでプレイヤーの正面に魔法を飛ばす
        if (Input.GetMouseButtonDown(0))
        {
            // 魔法発動時の杖の攻撃アニメーション再生
            _cameAnimator.SetBool("Attack", true);

            // 角度を変更
            Quaternion quaternion = transform.rotation * Quaternion.Euler(0, -90, 0);

            // 出現位置
            Vector3 pos = transform.GetChild(0).GetChild(0).transform.position;

            // 魔法が出現
            GameObject magic = (GameObject)Instantiate(_standardStatus.Prefab, pos, quaternion);

            // プレイヤーの正面に飛ばす
            Rigidbody rigidbody = magic.GetComponent<Rigidbody>();
            rigidbody.AddForce(transform.GetChild(0).GetChild(0).transform.forward * _standardStatus.Speed, ForceMode.Acceleration);

            // 設定した時間が経ったら消滅させる
            Destroy(magic, _standardStatus.DestoryTime);
        }
    }

    /// <summary>
    /// 特殊魔法の処理
    /// </summary>
    private void ShotMagicSpecial()
    {
        // 右クリックを押している間はマーカーが表示され、設置する箇所を決めることができる
        if (Input.GetMouseButton(1))
        {
            _drawMarker.Draw("IceMaker", _specialStatus.MakerPrefab);
        }

        // 右クリックを離すとマーカーが消えて、その場所に魔法が出現する
        if (Input.GetMouseButtonUp(1))
        {
            // 魔法発動時の杖の攻撃アニメーション再生
            _cameAnimator.SetBool("Attack", true);

            // マーカーを非表示にする
            _drawMarker.Draw("IceMaker", _specialStatus.MakerPrefab, false);

            // もし、魔法を設置できない箇所にマーカーが置かれてきた場合
            // 魔法は出現しない
            if (_drawMarker.IsPlacement != true) return;

            // 出現位置
            Vector3 pos = _drawMarker.GetMakerPosition;
            pos.y += 2.0f;

            // 魔法が出現
            GameObject magic = Instantiate(_specialStatus.Prefab, pos, transform.rotation);
        }
    }
}
