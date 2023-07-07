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
    ChestMonsterSliderHPBer m_chestMonsterSliderHPBer;

    private NavMeshAgent m_agent;

    private Animator m_animator;

    private void Start()
    {
        m_agent = GetComponent<NavMeshAgent>(); //�R���|�[�l���g���擾
        m_animator = GetComponent<Animator>(); //�A�j���[�^�[�R���|�[�l���g���擾
    }

    private void Update()
    {
        if (m_chestMonsterSliderHPBer.MimicCurrentHPProperty <= 0) //�~�~�b�N��HP�������ꍇ
        {
            return;
        }

        if (m_chestMonsterAnimationFlgSet.AttackOnFlgProperty) //�U���A�j���[�V�������o�����Ԃ������ꍇ
        {
            //�~�~�b�N���ړ������Ȃ�
            m_agent.isStopped = true;
            m_agent.velocity = Vector3.zero; //�ړ����x�𖳂���
        }
        else
        {
            //�~�~�b�N���ړ�������
            m_agent.isStopped = false;
        }

        //�A�j���[�V�����󋵂𖈃t���[���X�V����
        m_animator.SetBool("Attack", m_chestMonsterAnimationFlgSet.AttackOnFlgProperty);
        //�����蔻��󋵂𖈃t���[���X�V����
        m_chestMonsterCollider.SphereColliderProperty.enabled = m_chestMonsterCollider.AttackColliderOnFlgProperty;
        Debug.Log("�����蔻��̏�Ԃ�" + m_chestMonsterCollider.SphereColliderProperty.enabled + "�ł�(ChestMonsterAttack�N���X)");
    }

    public void OnDetectObject(Collider _collider)
    {
        //���m�����I�u�W�F�N�g�ɁuPlayer�v�̃^�O���t���Ă���΁A���̃I�u�W�F�N�g��ǂ�������
        if (_collider.CompareTag("Player"))
        {
            m_chestMonsterAnimationFlgSet.AttackOnFlgProperty = true;
        }
    }

    //�T�m�͈͂���v���C���[�����������Ɏ��s����֐�
    public void NotDetectObject(Collider _collider)
    {
        //���m�����I�u�W�F�N�g�ɁuPlayer�v�̃^�O���t���Ă���΁A���̃I�u�W�F�N�g��ǂ�������
        if (_collider.CompareTag("Player"))
        {
            m_chestMonsterAnimationFlgSet.AttackOnFlgProperty = true;
        }
    }
}