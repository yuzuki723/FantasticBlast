using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ChestMonsterMove : MonoBehaviour
{
    [SerializeField]
    [Tooltip("GetNavMeshAgentクラスのインスタンスを入れる")]
    private GetNavMeshAgent m_getNavMeshAgent;

    [SerializeField]
    [Tooltip("ChestMonsterSliderHPBerクラスのインスタンスを入れる")]
    private ChestMonsterSliderHPBer m_chestMonsterSliderHPBer;

    private Animator m_animator;
    private bool m_controlFlg; //if文制御用

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
            //ミミックはプレイヤーを永遠に追いかけ続ける
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