using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
//ナビメッシュエージェント取得用スクリプト
public class GetNavMeshAgent : MonoBehaviour
{
    public NavMeshAgent m_agent;
    static bool m_tauntingEndFlg; //Tauntingアニメーションが終わったかを判断するフラグ

    public void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_agent.isStopped = true;

        m_tauntingEndFlg = false;
    }

    public bool TauntingEndFlgProperty //セッターとゲッター両方の役割がある関数
    {
        get { return m_tauntingEndFlg; }
        set { m_tauntingEndFlg = value; }
    }
}