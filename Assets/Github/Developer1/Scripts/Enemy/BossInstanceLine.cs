using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInstanceLine : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�{�X������")]
    private GameObject m_boss;

    [SerializeField]
    [Tooltip("�G�t�F�N�g������")]
    private GameObject m_bossAppearanceEffect;

    [SerializeField]
    [Tooltip("�G�t�F�N�g�ƃ{�X���C���X�^���X�������ƂȂ�I�u�W�F�N�g������")]
    private GameObject m_standardObject;

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Player")) //������傪�v���C���[�̏ꍇ
        {
            //�G�t�F�N�g���C���X�^���X������
            Instantiate(m_bossAppearanceEffect, m_standardObject.transform.position + new Vector3(0, 10, 0), m_bossAppearanceEffect.transform.rotation);
            Invoke("BossInstance", 1f); //1�b���BossInstance�֐����Ăяo��
        }
    }

    private void BossInstance()
    {
        Instantiate(m_boss, m_standardObject.transform.position + new Vector3(0, 0, -5), m_boss.transform.rotation);
    }
}