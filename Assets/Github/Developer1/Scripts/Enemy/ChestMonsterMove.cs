using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ChestMonsterMove : MonoBehaviour
{
    [SerializeField]
    [Tooltip("GetNavMeshAgent�N���X�̃C���X�^���X������")]
    private GetNavMeshAgent m_getNavMeshAgent;

    [SerializeField]
    [Tooltip("ChestMonsterSliderHPBer�N���X�̃C���X�^���X������")]
    private ChestMonsterSliderHPBer m_chestMonsterSliderHPBer;

    private Animator m_animator;
    private bool m_controlFlg; //if������p

    private void Start()
    {
        m_animator = GetComponent<Animator>(); //�A�j���[�^�[�R���|�[�l���g���擾
        m_controlFlg = false; //����Ȃ�
    }

    private void Update()
    {
        if (m_chestMonsterSliderHPBer.MimicCurrentHPProperty <= 0) //�~�~�b�N��HP�������ꍇ
        {
            return;
        }

        m_animator.SetBool("Tracking", true); //�ǔ��A�j���[�V�������J�n����

        if (m_getNavMeshAgent.TauntingEndFlgProperty)
        {
            //�~�~�b�N�̓v���C���[���i���ɒǂ�����������
            m_getNavMeshAgent.m_agent.destination = GameObject.Find("Player").transform.position;

            if (m_controlFlg == false)
            {
                Debug.Log("�~�~�b�N�͓����܂�");
                m_getNavMeshAgent.m_agent.isStopped = false; //�ړ��o����悤�ɂ���
                m_controlFlg = true; //����if���ɓ����Ă��Ȃ��悤�ɐ��䂷��
            }
        }
    }
}