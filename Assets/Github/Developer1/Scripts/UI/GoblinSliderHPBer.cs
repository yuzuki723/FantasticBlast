using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]
public class GoblinSliderHPBer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("ゴブリンを倒した時のエフェクトを入れる")]
    private GameObject m_deadEffect;

    [SerializeField]
    [Tooltip("ゴブリンを倒した時のドロップアイテムを入れる")]
    private GameObject m_dropItem;

    private NavMeshAgent m_agent;
    private Animator m_animator; //アニメーターコンポーネント取得用
    public Canvas m_canvas;
    public Slider m_slider;
    static int m_goblinMaxHP = 100;
    public int m_goblinCurrentHP;

    // Start is called before the first frame update
    private void Start()
    {
        m_agent = GetComponent<NavMeshAgent>(); //コンポーネントを取得
        m_animator = GetComponent<Animator>(); //アニメーターコンポーネントを取得
        m_slider.value = 1; //スライダーをマックスにする
        m_goblinCurrentHP = m_goblinMaxHP; //ゴブリンのHP設定
    }

    // Update is called once per frame
    private void Update()
    {
        //GoblinCanvasをFPSCamera(MainCamera)に向かせる(ビルボードにする)
        m_canvas.transform.rotation = Camera.main.transform.rotation;
    }

    private void OnCollisionEnter(Collision _collision)
    {
        if (_collision.gameObject.tag == "Explosion")
        {
            //ゴブリンのダメージ処理↓
            int goblinDamage = 60;
            Debug.Log(goblinDamage + "ダメージ受けた");
            m_goblinCurrentHP = m_goblinCurrentHP - goblinDamage;

            //ゴブリンの最大HPにおける現在のHPをスライダーに反映させる
            m_slider.value = (float)m_goblinCurrentHP / (float)m_goblinMaxHP;

            if(m_goblinCurrentHP <= 0)
            {
                m_animator.SetBool("Die", true); //死亡アニメーションを開始する
                m_agent.isStopped = true; //ゴブリンを倒したので、動きを止める
                Debug.Log(m_agent.isStopped);
                Destroy(this.gameObject, 2f); //2秒後にゴブリンを削除する
                Invoke("EffectInstance", 1.7f); //1.7秒後に指定した関数を呼び出して実行する
                Debug.Log("ゴブリン削除しました");
            }
        }
    }

    private void EffectInstance()
    {
        GameObject effectInstance = Instantiate(m_deadEffect, transform.localPosition + new Vector3(0f, 0.5f, 0.5f), Quaternion.identity);
        Debug.Log("エフェクトを出しました");
        Destroy(effectInstance.gameObject, 2f); //2秒後にエフェクトを削除する
    }

    private void OnDestroy()
    {
        //ゴブリンが消えてからアイテムをドロップする
        Instantiate(m_dropItem, transform.localPosition + new Vector3(0f, 1f, 0.5f), Quaternion.identity);
        Debug.Log("ゴブリンがアイテムをドロップしました");
    }

    public int GoblinCurrentHPProperty //セッターとゲッター両方の役割がある関数
    {
        get { return m_goblinCurrentHP; }
        set { m_goblinCurrentHP = value; }
    }
}