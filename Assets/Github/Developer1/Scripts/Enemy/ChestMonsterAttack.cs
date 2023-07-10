using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ChestMonsterAttack : MonoBehaviour
{
    [SerializeField]
    [Tooltip("ChestMonsterAnimationFlgSet�N���X�̃C���X�^���X������")]
    private ChestMonsterAnimationFlgSet m_chestMonsterAnimationFlgSet;

    [SerializeField]
    [Tooltip("ChestMonsterCollider�N���X�̃C���X�^���X������")]
    private ChestMonsterCollider m_chestMonsterCollider;

    [SerializeField]
    [Tooltip("ChestMonsterSliderHPBer�N���X�̃C���X�^���X������")]
    private ChestMonsterSliderHPBer m_chestMonsterSliderHPBer;

    [SerializeField]
    [Tooltip("GetNavMeshAgent�N���X�̃C���X�^���X������")]
    private GetNavMeshAgent m_getNavMeshAgent;

    private GameObject m_player;
    private Animator m_animator;
    private bool m_attackAnimaOnFlg; //�U���A�j���[�V���������邩�𔻒f����t���O(�ߋ����U���A�j���[�V����)

    private void Start()
    {
        m_attackAnimaOnFlg = false;
        m_animator = GetComponent<Animator>(); //�A�j���[�^�[�R���|�[�l���g���擾
        m_player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (m_chestMonsterSliderHPBer.MimicCurrentHPProperty <= 0) //�~�~�b�N��HP�������ꍇ
        {
            return;
        }

        //�U���A�j���[�V�������o���鎞 or �~�~�b�N���ړ����Ă͂����Ȃ��t���O�������Ă��鎞
        if (m_attackAnimaOnFlg || m_chestMonsterAnimationFlgSet.DoNotMoveFlgProperty)
        {
            m_getNavMeshAgent.m_agent.velocity = Vector3.zero; //�~�~�b�N���ړ������Ȃ�
        }

        m_animator.SetBool("Attack", m_attackAnimaOnFlg); //�ߋ����U���A�j���[�V����
    }

    public void OnDetectObject(Collider _collider)
    {
        //���m�����I�u�W�F�N�g�ɁuPlayer�v�̃^�O���t���Ă���΁A���̃I�u�W�F�N�g��ǂ�������
        if (_collider.CompareTag("Player"))
        {
            m_attackAnimaOnFlg = true; //�U���A�j���[�V�������J�n����
        }
    }

    //�T�m�͈͂���v���C���[�����������Ɏ��s����֐�
    public void NotDetectObject(Collider _collider)
    {
        if (_collider.CompareTag("Player"))
        {
            m_attackAnimaOnFlg = false; //�U���A�j���[�V�������I������
        }
    }
}