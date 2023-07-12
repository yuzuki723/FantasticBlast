using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField, Tooltip("通常魔法のステータス")]
    private StandardStatus _standardStatus = new StandardStatus();
    [System.Serializable]
    public class StandardStatus
    {
        [SerializeField, Tooltip("通常魔法のPrefab")]
        public GameObject Prefab;

        [SerializeField, Tooltip("通常魔法の速度")]
        public float Speed = 100;

        [SerializeField, Tooltip("通常魔法の発射間隔")]
        public float Interval = 0.1f;

        [SerializeField, Tooltip("通常魔法が消滅するまでの時間")]
        public float DestoryTime = 1.0f;
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

    ///<summary>
    ///通常魔法が発射されてどれだけ時間が経過したか記録
    ///</summary>
    private float _elapsedCastTime = 0.0f;

    /// <summary>
    /// 杖のアニメーター
    /// </summary>
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
    /// 土魔法実行
    /// </summary>
    public void ShotStoneMagic()
    {
        // 左クリックを押している間、魔法を連射する
        ShotMagicStandard();

        // 右クリックを長押しで魔法を設置する場所を決めて、離すと魔法が設置される
        ShotMagicSpecial();

        // 魔法を発動していない時はアニメーションさせない
        _cameAnimator.SetBool("Attack",false);
    }

    /// <summary>
    /// 通常魔法の処理
    /// </summary>
    private void ShotMagicStandard()
    {
        // 均一な間隔で魔法を発射するようにする
        if (Input.GetMouseButton(0) && _elapsedCastTime <= 0.0f)
        {
            // 魔法発動時の杖の攻撃アニメーション再生
            _cameAnimator.SetBool("Attack", true);

            // 出現位置
            Vector3 pos = transform.GetChild(0).GetChild(0).transform.position;

            // 魔法を出現させる
            GameObject magic = (GameObject)Instantiate(_standardStatus.Prefab, pos, Random.rotation);

            // プレイヤーの正面に飛ばす
            Rigidbody rigidbody = magic.GetComponent<Rigidbody>();
            rigidbody.AddForce(transform.GetChild(0).GetChild(0).transform.forward * _standardStatus.Speed);

            // 1秒後に消滅する
            Destroy(magic, _standardStatus.DestoryTime);

            // 連射防止のためインターバルを設ける
            _elapsedCastTime = _standardStatus.Interval;
        }

        //時間を減らしていき、０になったら魔法を打てるようにする
        if (_elapsedCastTime > 0.0f)
        {
            _elapsedCastTime -= Time.deltaTime;
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
            _drawMarker.Draw("StoneMaker", _specialStatus.MakerPrefab);
        }

        // 右クリックを離すとマーカーが消えて、その場所に魔法が出現する
        if (Input.GetMouseButtonUp(1))
        {
            // 魔法発動時の杖の攻撃アニメーション再生
            _cameAnimator.SetBool("Attack", true);

            // マーカーを非表示にする
            _drawMarker.Draw("StoneMaker", _specialStatus.MakerPrefab, false);

            // もし、魔法を設置できない箇所にマーカーが置かれてきた場合
            // 魔法は出現しない
            if (_drawMarker.IsPlacement != true) return;

            // 魔法は下から徐々に出現するので、座標を少し下げる
            Vector3 startPos = _drawMarker.GetMakerPosition;
            startPos.y -= 2.0f;

            // 魔法を生成
            Instantiate(_specialStatus.Prefab, startPos, transform.rotation);
        }
    }
}
