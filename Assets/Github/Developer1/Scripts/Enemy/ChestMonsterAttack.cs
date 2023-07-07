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
    ChestMonsterSliderHPBer m_chestMonsterSliderHPBer;

    private NavMeshAgent m_agent;

    private Animator m_animator;

    private void Start()
    {
        m_agent = GetComponent<NavMeshAgent>(); //コンポーネントを取得
        m_animator = GetComponent<Animator>(); //アニメーターコンポーネントを取得
    }

    private void Update()
    {
        if (m_chestMonsterSliderHPBer.MimicCurrentHPProperty <= 0) //ミミックのHPが無い場合
        {
            return;
        }

        if (m_chestMonsterAnimationFlgSet.AttackOnFlgProperty) //攻撃アニメーションが出来る状態だった場合
        {
            //ミミックを移動させない
            m_agent.isStopped = true;
            m_agent.velocity = Vector3.zero; //移動速度を無くす
        }
        else
        {
            //ミミックを移動させる
            m_agent.isStopped = false;
        }

        //アニメーション状況を毎フレーム更新する
        m_animator.SetBool("Attack", m_chestMonsterAnimationFlgSet.AttackOnFlgProperty);
        //当たり判定状況を毎フレーム更新する
        m_chestMonsterCollider.SphereColliderProperty.enabled = m_chestMonsterCollider.AttackColliderOnFlgProperty;
        Debug.Log("当たり判定の状態は" + m_chestMonsterCollider.SphereColliderProperty.enabled + "です(ChestMonsterAttackクラス)");
    }

    public void OnDetectObject(Collider _collider)
    {
        //検知したオブジェクトに「Player」のタグが付いていれば、そのオブジェクトを追いかける
        if (_collider.CompareTag("Player"))
        {
            m_chestMonsterAnimationFlgSet.AttackOnFlgProperty = true;
        }
    }

    //探知範囲からプレイヤーが消えた時に実行する関数
    public void NotDetectObject(Collider _collider)
    {
        //検知したオブジェクトに「Player」のタグが付いていれば、そのオブジェクトを追いかける
        if (_collider.CompareTag("Player"))
        {
            m_chestMonsterAnimationFlgSet.AttackOnFlgProperty = true;
        }
    }
}