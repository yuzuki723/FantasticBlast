using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class GoblinAttack : MonoBehaviour
{
    private NavMeshAgent m_agent;
    private Animator m_animator;
    static bool m_handColliderFlg; //�S�u�����̎�̓����蔻���t���邩�𔻒f����

    // Start is called before the first frame update
    private void Start()
    {
        m_agent = GetComponent<NavMeshAgent>(); //�R���|�[�l���g���擾
        m_animator = GetComponent<Animator>(); //�A�j���[�^�[�R���|�[�l���g���擾
        m_handColliderFlg = false;
    }

    //�v���C���[��T�m�������Ɏ��s����֐�
    public void OnDetectObject(Collider _collider)
    {
        //���m�����I�u�W�F�N�g�ɁuPlayer�v�̃^�O���t���Ă���΁A���̃I�u�W�F�N�g��ǂ�������
        if (_collider.CompareTag("Player"))
        {
            m_handColliderFlg = true; //��̓����蔻���t����
            m_animator.SetBool("Attack", true); //�U���A�j���[�V�������J�n����
            Debug.Log(m_animator.GetBool("Attack"));
            m_agent.velocity = Vector3.zero; //�U���͈͂ɓ������̂ŁA�S�u�����̈ړ����x�𖳂���(velocity == ���x)  
        }
    }

    //�T�m�͈͂���v���C���[�����������Ɏ��s����֐�
    public void NotDetectObject(Collider _collider)
    {
        if (_collider.CompareTag("Player"))
        {
            m_handColliderFlg = false; //��̓����蔻��𖳂���
            m_animator.SetBool("Attack", false); //�U���A�j���[�V�������I������
            Debug.Log(m_animator.GetBool("Attack"));
        }
    }

    public bool HandColliderFlgProperty //�Z�b�^�[�ƃQ�b�^�[�����̖���������֐�
    {
        get { return m_handColliderFlg; }
        set { m_handColliderFlg = value; }
    }
}