using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ChestMonsterAttack : MonoBehaviour
{
    [SerializeField]
    [Tooltip("ChestMonsterAnimationFlgSetクラスのインスタンスを入れる")]
    private ChestMonsterAnimationFlgSet m_chestMonsterAnimationFlgSet;

    [SerializeField]
    [Tooltip("ChestMonsterColliderクラスのインスタンスを入れる")]
    private ChestMonsterCollider m_chestMonsterCollider;

    [SerializeField]
    [Tooltip("ChestMonsterSliderHPBerクラスのインスタンスを入れる")]
    private ChestMonsterSliderHPBer m_chestMonsterSliderHPBer;

    [SerializeField]
    [Tooltip("GetNavMeshAgentクラスのインスタンスを入れる")]
    private GetNavMeshAgent m_getNavMeshAgent;

    private GameObject m_player;
    private Animator m_animator;
    private bool m_attackAnimaOnFlg; //攻撃アニメーションをするかを判断するフラグ(近距離攻撃アニメーション)

    private void Start()
    {
        m_attackAnimaOnFlg = false;
        m_animator = GetComponent<Animator>(); //アニメーターコンポーネントを取得
        m_player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (m_chestMonsterSliderHPBer.MimicCurrentHPProperty <= 0) //ミミックのHPが無い場合
        {
            return;
        }

        //攻撃アニメーションが出来る時 or ミミックが移動してはいけないフラグが立っている時
        if (m_attackAnimaOnFlg || m_chestMonsterAnimationFlgSet.DoNotMoveFlgProperty)
        {
            m_getNavMeshAgent.m_agent.velocity = Vector3.zero; //ミミックを移動させない
        }

        m_animator.SetBool("Attack", m_attackAnimaOnFlg); //近距離攻撃アニメーション
    }

    public void OnDetectObject(Collider _collider)
    {
        //検知したオブジェクトに「Player」のタグが付いていれば、そのオブジェクトを追いかける
        if (_collider.CompareTag("Player"))
        {
            m_attackAnimaOnFlg = true; //攻撃アニメーションを開始する
        }
    }

    //探知範囲からプレイヤーが消えた時に実行する関数
    public void NotDetectObject(Collider _collider)
    {
        if (_collider.CompareTag("Player"))
        {
            m_attackAnimaOnFlg = false; //攻撃アニメーションを終了する
        }
    }
}