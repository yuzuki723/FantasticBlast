using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ChestMonsterSliderHPBer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("ミミックを倒した時のエフェクトを入れる")]
    private GameObject m_deadEffect;

    [SerializeField]
    [Tooltip("ミミックを倒した時のドロップアイテムを入れる")]
    private GameObject m_dropItem;

    [SerializeField]
    [Tooltip("GetNavMeshAgentクラスのインスタンスを入れる")]
    GetNavMeshAgent m_getNavMeshAgent;

    private Animator m_animator; //アニメーターコンポーネント取得用
    public Canvas m_canvas;
    public Slider m_slider;
    static int m_mimicMaxHP = 100;
    public int m_mimicCurrentHP;

    // Start is called before the first frame update
    private void Start()
    {
        m_animator = GetComponent<Animator>(); //アニメーターコンポーネントを取得
        m_slider.value = 1; //スライダーをマックスにする
        m_mimicCurrentHP = m_mimicMaxHP; //ミミックのHP設定
    }

    // Update is called once per frame
    private void Update()
    {
        //CestMonsterCanvasをFPSCamera(MainCamera)に向かせる(ビルボードにする)
        m_canvas.transform.rotation = Camera.main.transform.rotation;
    }

    private void OnCollisionEnter(Collision _collision)
    {
        if (_collision.gameObject.tag == "Explosion")
        {
            //ミミックのダメージ処理↓
            int mimicDamage = 60;
            Debug.Log(mimicDamage + "ダメージ受けた");
            m_mimicCurrentHP = m_mimicCurrentHP - mimicDamage;

            //ミミックの最大HPにおける現在のHPをスライダーに反映させる
            m_slider.value = (float)m_mimicCurrentHP / (float)m_mimicMaxHP;

            if (m_mimicCurrentHP <= 0)
            {
                m_animator.SetBool("Die", true); //死亡アニメーションを開始する
                m_getNavMeshAgent.m_agent.isStopped = true; //ミミックを倒したので、動きを止める
                Destroy(this.gameObject, 2f); //2秒後にミミックを削除する
                Invoke("EffectInstance", 1.7f); //1.7秒後に指定した関数を呼び出して実行する
                Debug.Log("ミミックを削除しました");
            }
        }
    }

    private void EffectInstance()
    {
        GameObject effectInstance = Instantiate(m_deadEffect, transform.localPosition + new Vector3(0f, 0.5f, 0.5f), Quaternion.identity);
        Destroy(effectInstance.gameObject, 2f); //2秒後にエフェクトを削除する
    }

    private void OnDestroy()
    {
        //ミミックが消えてからアイテムをドロップする
        Instantiate(m_dropItem, transform.localPosition + new Vector3(0f, 1f, 0.5f), Quaternion.identity);
        Debug.Log("ミミックがアイテムをドロップしました");
    }

    public int MimicCurrentHPProperty //セッターとゲッター両方の役割がある関数
    {
        get { return m_mimicCurrentHP; }
        set { m_mimicCurrentHP = value; }
    }
}