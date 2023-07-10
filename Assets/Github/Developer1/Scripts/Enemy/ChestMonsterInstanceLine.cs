using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMonsterInstanceLine : MonoBehaviour
{
    //�G�p---------------------------------------------
    [SerializeField]
    [Tooltip("�C���X�^���X������G������")]
    private GameObject m_enemyInstance;

    [SerializeField]
    [Tooltip("1�̖ڂ̓G���C���X�^���X�������ƂȂ�I�u�W�F�N�g������")]
    private GameObject m_enemyStandardObject;

    private int m_enemyInstNumber; //�G���C���X�^���X�����鐔
    private int m_instanceCounter; //�C���X�^���X������G�̐��𐔂���
    //�G���C���X�^���X��������W
    Vector3 m_firstEnemyInstancePos;
    Vector3 m_secondEnemyInstancePos;
    Vector3 m_thirdEnemyInstancePos;
    //-------------------------------------------------

    //���𕕍�����W�Q�G�t�F�N�g�p---------------------
    [SerializeField]
    [Tooltip("�C���X�^���X������G�t�F�N�g������")]
    private GameObject m_effectInstance;

    [SerializeField]
    [Tooltip("�G�t�F�N�g���C���X�^���X�������ƂȂ�I�u�W�F�N�g������")]
    private GameObject m_effectStandardObject;

    Vector3 m_effectInstancePos;
    //-------------------------------------------------

    private void Start()
    {
        m_enemyInstNumber = 3;
        m_instanceCounter = 0;

        //3�̂̓G�̃C���X�^���X��������W�����炷(�Œ�ʒu)
        m_firstEnemyInstancePos = m_enemyStandardObject.gameObject.transform.position;
        m_secondEnemyInstancePos = m_firstEnemyInstancePos + new Vector3(-20f, 0f, 0f);
        m_thirdEnemyInstancePos = m_secondEnemyInstancePos + new Vector3(-20f, 0f, 0f);

        //�G�t�F�N�g���C���X�^���X��������W���L�^����
        m_effectInstancePos = m_effectStandardObject.gameObject.transform.position;
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Player")) //������傪�v���C���[�̏ꍇ
        {
            if (m_instanceCounter < m_enemyInstNumber) //m_enemyInstNumber�ɒ�`�����������������G���C���X�^���X�����Ȃ�
            {
                for(; m_instanceCounter < m_enemyInstNumber; m_instanceCounter++)
                {
                    //�~�~�b�N�̃C���X�^���X��(���ꂼ����W���قȂ�)
                    if (m_instanceCounter == 0)
                    {
                        EnemyInstance(m_firstEnemyInstancePos);
                    }
                    else
                    {
                        if(m_instanceCounter == 1)
                        {
                            EnemyInstance(m_secondEnemyInstancePos);
                        }
                        else
                        {
                            EnemyInstance(m_thirdEnemyInstancePos);
                        }
                    }
                }

                //�G�t�F�N�g���C���X�^���X��
                Instantiate(m_effectInstance, m_effectInstancePos, m_effectInstance.transform.rotation);
            }
        }
    }

    private void EnemyInstance(Vector3 _instancePos)
    {
        Instantiate(m_enemyInstance, new Vector3(_instancePos.x, _instancePos.y, _instancePos.z), m_enemyInstance.transform.rotation);
    }
}