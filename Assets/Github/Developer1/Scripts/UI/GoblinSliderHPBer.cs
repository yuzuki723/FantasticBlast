using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]
public class GoblinSliderHPBer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�S�u������|�������̃G�t�F�N�g������")]
    private GameObject m_deadEffect;

    [SerializeField]
    [Tooltip("�S�u������|�������̃h���b�v�A�C�e��������")]
    private GameObject m_dropItem;

    private NavMeshAgent m_agent;
    private Animator m_animator; //�A�j���[�^�[�R���|�[�l���g�擾�p
    public Canvas m_canvas;
    public Slider m_slider;
    static int m_goblinMaxHP = 100;
    public int m_goblinCurrentHP;

    // Start is called before the first frame update
    private void Start()
    {
        m_agent = GetComponent<NavMeshAgent>(); //�R���|�[�l���g���擾
        m_animator = GetComponent<Animator>(); //�A�j���[�^�[�R���|�[�l���g���擾
        m_slider.value = 1; //�X���C�_�[���}�b�N�X�ɂ���
        m_goblinCurrentHP = m_goblinMaxHP; //�S�u������HP�ݒ�
    }

    // Update is called once per frame
    private void Update()
    {
        //GoblinCanvas��FPSCamera(MainCamera)�Ɍ�������(�r���{�[�h�ɂ���)
        m_canvas.transform.rotation = Camera.main.transform.rotation;
    }

    private void OnCollisionEnter(Collision _collision)
    {
        if (_collision.gameObject.tag == "Explosion")
        {
            //�S�u�����̃_���[�W������
            int goblinDamage = 60;
            Debug.Log(goblinDamage + "�_���[�W�󂯂�");
            m_goblinCurrentHP = m_goblinCurrentHP - goblinDamage;

            //�S�u�����̍ő�HP�ɂ����錻�݂�HP���X���C�_�[�ɔ��f������
            m_slider.value = (float)m_goblinCurrentHP / (float)m_goblinMaxHP;

            if(m_goblinCurrentHP <= 0)
            {
                m_animator.SetBool("Die", true); //���S�A�j���[�V�������J�n����
                m_agent.isStopped = true; //�S�u������|�����̂ŁA�������~�߂�
                Debug.Log(m_agent.isStopped);
                Destroy(this.gameObject, 2f); //2�b��ɃS�u�������폜����
                Invoke("EffectInstance", 1.7f); //1.7�b��Ɏw�肵���֐����Ăяo���Ď��s����
                Debug.Log("�S�u�����폜���܂���");
            }
        }
    }

    private void EffectInstance()
    {
        GameObject effectInstance = Instantiate(m_deadEffect, transform.localPosition + new Vector3(0f, 0.5f, 0.5f), Quaternion.identity);
        Debug.Log("�G�t�F�N�g���o���܂���");
        Destroy(effectInstance.gameObject, 2f); //2�b��ɃG�t�F�N�g���폜����
    }

    private void OnDestroy()
    {
        //�S�u�����������Ă���A�C�e�����h���b�v����
        Instantiate(m_dropItem, transform.localPosition + new Vector3(0f, 1f, 0.5f), Quaternion.identity);
        Debug.Log("�S�u�������A�C�e�����h���b�v���܂���");
    }

    public int GoblinCurrentHPProperty //�Z�b�^�[�ƃQ�b�^�[�����̖���������֐�
    {
        get { return m_goblinCurrentHP; }
        set { m_goblinCurrentHP = value; }
    }
}