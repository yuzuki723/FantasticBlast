using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class GoblinMove : MonoBehaviour
{
    //�S�u�����̐F��ς���
    //�o������ہA�������炾�񂾂�ƕs�����ɂȂ��ďo�Ă���

    public GoblinSliderHPBer m_goblinSliderHPBer;
    private Animator m_animator;
    private NavMeshAgent m_agent;

    // Start is called before the first frame update
    private void Start()
    {
        m_agent = GetComponent<NavMeshAgent>(); //�R���|�[�l���g���擾
        m_animator = GetComponent<Animator>(); //�A�j���[�^�[�R���|�[�l���g���擾
    }

    private void Update()
    {
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);
        //}
        //else
        //{
        //    GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
        //}
    }

    //�v���C���[��T�m�������Ɏ��s����֐�
    public void OnDetectObject(Collider _collider)
    {
        Debug.Log("�S�u�����͐���ł�");
        //���m�����I�u�W�F�N�g�ɁuPlayer�v�̃^�O���t���Ă���΁A���̃I�u�W�F�N�g��ǂ�������
        if (_collider.CompareTag("Player"))
        {
            m_agent.destination = _collider.transform.position;
            m_animator.SetBool("Move", true); //�ǔ��A�j���[�V�������J�n����

            if (m_goblinSliderHPBer.m_goblinCurrentHP <= 0)
            {
                m_agent.isStopped = true; //�S�u�����̓������~�߂�
            }
            else
            {
                m_agent.isStopped = false; //�S�u����������
            }
        }
    }

    //�T�m�͈͂���v���C���[�����������Ɏ��s����֐�
    public void NotDetectObject(Collider _collider)
    {
        //���m�����I�u�W�F�N�g�ɁuPlayer�v�̃^�O���t���Ă���΁A���̃I�u�W�F�N�g��ǂ�������
        if (_collider.CompareTag("Player"))
        {
            m_agent.destination = _collider.transform.position;
            m_animator.SetBool("Move", false); //�ǔ��A�j���[�V�������I������
            m_agent.isStopped = true; //�S�u�����̓������~�߂�
            m_agent.velocity = Vector3.zero;
        }
    }
}