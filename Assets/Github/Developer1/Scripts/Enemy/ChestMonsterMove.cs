using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ChestMonsterMove : MonoBehaviour
{
    [SerializeField]
    [Tooltip("GetNavMeshAgentクラスのインスタンスを入れる")]
    GetNavMeshAgent m_getNavMeshAgent;

    [SerializeField]
    [Tooltip("ChestMonsterSliderHPBerクラスのインスタンスを入れる")]
    ChestMonsterSliderHPBer m_chestMonsterSliderHPBer;

    private Animator m_animator;

    private bool m_controlFlg; //if文制御用

    //この他にもChestMonsterAttackクラスを作り、そのクラスに
    //ミミックに2つの攻撃を実装する。
    //その2つの攻撃は近距離攻撃と遠距離攻撃。
    //＜＜近距離攻撃＞＞
    //プレイヤーと一定距離以下になった時に攻撃をする。
    //＜＜遠距離攻撃＞＞
    //プレイヤーとの距離が離れている時(近距離攻撃の範囲外の時)に確率で攻撃する。
    //(確率は低めにする100分20ぐらいに)
    //近距離攻撃の方が威力が高い
    //ミミックの移動速度はゴブリンよりは速い

    private void Start()
    {
        m_animator = GetComponent<Animator>(); //アニメーターコンポーネントを取得
        m_controlFlg = false; //制御なし
    }

    private void Update()
    {
        if (m_chestMonsterSliderHPBer.MimicCurrentHPProperty <= 0) //ミミックのHPが無い場合
        {
            return;
        }

        m_animator.SetBool("Tracking", true); //追尾アニメーションを開始する

        if (m_getNavMeshAgent.TauntingEndFlgProperty)
        {
            m_getNavMeshAgent.m_agent.destination = GameObject.Find("Player").transform.position;

            if (m_controlFlg == false)
            {
                Debug.Log("ミミックは動けます");
                m_getNavMeshAgent.m_agent.isStopped = false; //移動出来るようにする
                m_controlFlg = true; //このif文に入ってこないように制御する
            }
        }
    }
}