using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabotageEffectInstance : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�C���X�^���X������G�t�F�N�g������")]
    private GameObject m_effectInstance;

    [SerializeField]
    [Tooltip("�G�t�F�N�g���C���X�^���X�������ƂȂ�I�u�W�F�N�g������")]
    private GameObject m_standardObject;

    private Vector3 m_effectInstancePos; //�G�t�F�N�g���C���X�^���X��������W
    static bool m_playerInvasionFlg; //�v���C���[�����C�����z�������𔻒f����t���O

    // Start is called before the first frame update
    private void Start()
    {
        //�G�t�F�N�g���C���X�^���X��������W���L�^����
        m_effectInstancePos = m_standardObject.gameObject.transform.position;
        m_playerInvasionFlg = false;
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (m_playerInvasionFlg == false && _other.CompareTag("Player")) //������傪�v���C���[�̏ꍇ
        {
            //�G�t�F�N�g���C���X�^���X��
            Instantiate(m_effectInstance, m_effectInstancePos, m_effectInstance.transform.rotation);
            m_playerInvasionFlg = true; //�v���C���[�����C�����z����
        }
    }
}