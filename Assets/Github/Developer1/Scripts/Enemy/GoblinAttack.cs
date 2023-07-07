using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class GoblinAttack : MonoBehaviour
{
    private NavMeshAgent m_agent;
    private Animator m_animator;
    static bool m_handColliderFlg; //ゴブリンの手の当たり判定を付けるかを判断する

    // Start is called before the first frame update
    private void Start()
    {
        m_agent = GetComponent<NavMeshAgent>(); //コンポーネントを取得
        m_animator = GetComponent<Animator>(); //アニメーターコンポーネントを取得
        m_handColliderFlg = false;
    }

    //プレイヤーを探知した時に実行する関数
    public void OnDetectObject(Collider _collider)
    {
        //検知したオブジェクトに「Player」のタグが付いていれば、そのオブジェクトを追いかける
        if (_collider.CompareTag("Player"))
        {
            m_handColliderFlg = true; //手の当たり判定を付ける
            m_animator.SetBool("Attack", true); //攻撃アニメーションを開始する
            Debug.Log(m_animator.GetBool("Attack"));
            m_agent.velocity = Vector3.zero; //攻撃範囲に入ったので、ゴブリンの移動速度を無くす(velocity == 速度)  
        }
    }

    //探知範囲からプレイヤーが消えた時に実行する関数
    public void NotDetectObject(Collider _collider)
    {
        if (_collider.CompareTag("Player"))
        {
            m_handColliderFlg = false; //手の当たり判定を無くす
            m_animator.SetBool("Attack", false); //攻撃アニメーションを終了する
            Debug.Log(m_animator.GetBool("Attack"));
        }
    }

    public bool HandColliderFlgProperty //セッターとゲッター両方の役割がある関数
    {
        get { return m_handColliderFlg; }
        set { m_handColliderFlg = value; }
    }
}