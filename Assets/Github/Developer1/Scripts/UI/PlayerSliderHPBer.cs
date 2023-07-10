using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSliderHPBer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�v���C���[HP�̏����l")]
    private int m_playerMaxHP;
    private int m_playerCurrentHP;

    [SerializeField]
    [Tooltip("�X���C�_�[������")]
    private Slider m_slider;

    private bool m_magicCircleRecoveryFlg; //�v���C���[�����@�w�ŉ񕜂������𔻒f����t���O

    // Start is called before the first frame update
    private void Start()
    {
        m_slider.value = 1; //�X���C�_�[���}�b�N�X�ɂ���
        m_playerCurrentHP = m_playerMaxHP; //�v���C���[��HP�ݒ�
        m_magicCircleRecoveryFlg = false;
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("GoblinRightHand")) //�����������̂��S�u�����̉E�肾�����ꍇ
        {
            int playerDamage = 50; //�v���C���[�̃_���[�W��
            m_playerCurrentHP = m_playerCurrentHP - playerDamage;
            Debug.Log("�S�u�����ɂ����" + playerDamage + "�_���[�W�󂯂�");
        }
        else
        {
            if (_other.CompareTag("Heart")) //�����������̂��n�[�g�������ꍇ
            {
                int playerRecovery = 30; //�v���C���[��HP�񕜗�
                m_playerCurrentHP = m_playerCurrentHP + playerRecovery;
                Debug.Log("�v���C���[��" + playerRecovery + "�񕜂��܂���");
                Destroy(_other.gameObject); //�s�K�v�ɂȂ����̂Ńn�[�g���폜����
            }
            else
            {
                if (_other.CompareTag("MimicTooth")) //�����������̂��~�~�b�N�������ꍇ
                {
                    int playerDamage = 40; //�v���C���[�̃_���[�W��
                    m_playerCurrentHP = m_playerCurrentHP - playerDamage;
                    Debug.Log("�~�~�b�N�ɂ����" + playerDamage + "�_���[�W�󂯂�");
                }
                else
                {
                    if(m_magicCircleRecoveryFlg == false && _other.CompareTag("HeelMagicCircle")) //�����������̂����@�w�������ꍇ
                    {
                        m_playerCurrentHP = m_playerMaxHP;
                        Debug.Log("���@�w�ŉ�  ���݂�HP��" + m_playerCurrentHP + "�ł�");
                        m_magicCircleRecoveryFlg = true; //�v���C���[�����@�w�ŉ񕜂���
                    }
                }
            }
        }

        if (m_playerCurrentHP <= 0)
        {
            m_playerCurrentHP = 0;
        }
        else
        {
            if(m_playerCurrentHP >= 500)
            {
                m_playerCurrentHP = 500;
            }
        }

        //�v���C���[�̍ő�HP�ɂ����錻�݂�HP���X���C�_�[�ɔ��f������
        m_slider.value = (float)m_playerCurrentHP / (float)m_playerMaxHP;
    }
}