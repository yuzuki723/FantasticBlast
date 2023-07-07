using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
//�i�r���b�V���G�[�W�F���g�擾�p�X�N���v�g
public class GetNavMeshAgent : MonoBehaviour
{
    public NavMeshAgent m_agent;
    static bool m_tauntingEndFlg; //Taunting�A�j���[�V�������I��������𔻒f����t���O

    public void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_agent.isStopped = true;

        m_tauntingEndFlg = false;
    }

    public bool TauntingEndFlgProperty //�Z�b�^�[�ƃQ�b�^�[�����̖���������֐�
    {
        get { return m_tauntingEndFlg; }
        set { m_tauntingEndFlg = value; }
    }
}