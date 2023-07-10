using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinInstanceLine : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�C���X�^���X������G������")]
    private GameObject m_enemyInstance;

    [SerializeField]
    [Tooltip("�G���C���X�^���X������͈�A������")]
    private Transform m_instanceRangeA;

    [SerializeField]
    [Tooltip("�G���C���X�^���X������͈�B������")]
    private Transform m_instanceRangeB;

    [SerializeField]
    [Tooltip("�C���X�^���X������G�̐�������")]
    private int m_enemyInstNumber;

    private int m_enemyInstanceCounter; //�C���X�^���X������G�̐��𐔂���
    static bool m_playerInvasionFlg; //�v���C���[�����C�����z�������𔻒f����t���O

    private void Start()
    {
        m_enemyInstanceCounter = 0;
        m_playerInvasionFlg = false;
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Player")) //������傪�v���C���[�̏ꍇ
        {
            if (m_enemyInstanceCounter < m_enemyInstNumber) //m_enemyInstNumber�ɒ�`�����������������G���C���X�^���X�����Ȃ�
            {
                for (; m_enemyInstanceCounter < m_enemyInstNumber; m_enemyInstanceCounter++)
                {
                    //�G��XYZ�����_���Ȉʒu�ɃC���X�^���X������
                    float instancePosX = Random.Range(m_instanceRangeA.position.x, m_instanceRangeB.position.x);
                    float instancePosY = Random.Range(m_instanceRangeA.position.y, m_instanceRangeB.position.y);
                    float instancePosZ = Random.Range(m_instanceRangeA.position.z, m_instanceRangeB.position.z);

                    Instantiate(m_enemyInstance, new Vector3(instancePosX, instancePosY, instancePosZ), m_enemyInstance.transform.rotation);
                }
            }

            m_playerInvasionFlg = true; //�v���C���[�����C�����z����
        }
    }
    
    public bool PlayerInvasionFlgProperty //�Z�b�^�[�ƃQ�b�^�[�����̖���������֐�
    {
        get { return m_playerInvasionFlg; }
        set { m_playerInvasionFlg = value; }
    }
}