using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_Fire_Special : MonoBehaviour
{

    private MagicParent m_magic;

    [SerializeField] GameObject m_fire_Special;
    [SerializeField] GameObject m_appearancePlace;


    //�A�j���[�^�[�R���|�[�l���g�擾�p
    private Animator m_animator;

    //���@�����̃N�[���^�C��
    int m_magicCoolTime;

    private float m_moveSpeed = 600;

    void Start()
    {
        m_magic = GetComponent<MagicParent>();

        m_appearancePlace = transform.GetChild(0).gameObject;
        m_animator = GetComponent<Animator>(); //�A�j���[�^�[�R���|�[�l���g���擾
        m_magicCoolTime = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        //�N�[���^�C���̌��炷
        DecreaseMagicCoolTime();

        if(m_magicCoolTime == 0)
        {
            ShotMagic();
        }
        else
        {
            m_animator.SetBool("Attack", false);
        }
    }

    //�N�[���^�C������
    private void DecreaseMagicCoolTime()
    {
        --m_magicCoolTime;

        //0��菬�������Ȃ�
        if(m_magicCoolTime < 0)
        {
            m_magicCoolTime = 0;
        }
    }

    //���@����
    private void ShotMagic()
    {
        //�E�N���b�N���������Ă��Ȃ������瑁�����^�[��
        if (m_magic.IsSpecialMagicFlg() != true) return;

        //���@���o��
        GameObject ball = (GameObject)Instantiate(m_fire_Special, m_appearancePlace.transform.position, Quaternion.identity);
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();

        //�v���C���[�̐��ʂɔ�΂�
        ballRigidbody.AddForce(transform.forward * m_moveSpeed);

        m_animator.SetBool("Attack", true); //���@�̏�̃A�^�b�N�A�j���[�V�������J�n����

        m_magicCoolTime = 60 * 12; //�N�[���^�C����݂���
    }
}
