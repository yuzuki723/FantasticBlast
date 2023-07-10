using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ChestMonsterSliderHPBer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�~�~�b�N��|�������̃G�t�F�N�g������")]
    private GameObject m_deadEffect;

    [SerializeField]
    [Tooltip("�~�~�b�N��|�������̃h���b�v�A�C�e��������")]
    private GameObject m_dropItem;

    [SerializeField]
    [Tooltip("GetNavMeshAgent�N���X�̃C���X�^���X������")]
    GetNavMeshAgent m_getNavMeshAgent;

    private Animator m_animator; //�A�j���[�^�[�R���|�[�l���g�擾�p
    public Canvas m_canvas;
    public Slider m_slider;
    static int m_mimicMaxHP = 100;
    public int m_mimicCurrentHP;

    // Start is called before the first frame update
    private void Start()
    {
        m_animator = GetComponent<Animator>(); //�A�j���[�^�[�R���|�[�l���g���擾
        m_slider.value = 1; //�X���C�_�[���}�b�N�X�ɂ���
        m_mimicCurrentHP = m_mimicMaxHP; //�~�~�b�N��HP�ݒ�
    }

    // Update is called once per frame
    private void Update()
    {
        //CestMonsterCanvas��FPSCamera(MainCamera)�Ɍ�������(�r���{�[�h�ɂ���)
        m_canvas.transform.rotation = Camera.main.transform.rotation;
    }

    private void OnCollisionEnter(Collision _collision)
    {
        if (_collision.gameObject.tag == "Explosion")
        {
            //�~�~�b�N�̃_���[�W������
            int mimicDamage = 60;
            Debug.Log(mimicDamage + "�_���[�W�󂯂�");
            m_mimicCurrentHP = m_mimicCurrentHP - mimicDamage;

            //�~�~�b�N�̍ő�HP�ɂ����錻�݂�HP���X���C�_�[�ɔ��f������
            m_slider.value = (float)m_mimicCurrentHP / (float)m_mimicMaxHP;

            if (m_mimicCurrentHP <= 0)
            {
                m_animator.SetBool("Die", true); //���S�A�j���[�V�������J�n����
                m_getNavMeshAgent.m_agent.isStopped = true; //�~�~�b�N��|�����̂ŁA�������~�߂�
                Destroy(this.gameObject, 2f); //2�b��Ƀ~�~�b�N���폜����
                Invoke("EffectInstance", 1.7f); //1.7�b��Ɏw�肵���֐����Ăяo���Ď��s����
                Debug.Log("�~�~�b�N���폜���܂���");
            }
        }
    }

    private void EffectInstance()
    {
        GameObject effectInstance = Instantiate(m_deadEffect, transform.localPosition + new Vector3(0f, 0.5f, 0.5f), Quaternion.identity);
        Destroy(effectInstance.gameObject, 2f); //2�b��ɃG�t�F�N�g���폜����
    }

    private void OnDestroy()
    {
        //�~�~�b�N�������Ă���A�C�e�����h���b�v����
        Instantiate(m_dropItem, transform.localPosition + new Vector3(0f, 1f, 0.5f), Quaternion.identity);
        Debug.Log("�~�~�b�N���A�C�e�����h���b�v���܂���");
    }

    public int MimicCurrentHPProperty //�Z�b�^�[�ƃQ�b�^�[�����̖���������֐�
    {
        get { return m_mimicCurrentHP; }
        set { m_mimicCurrentHP = value; }
    }
}