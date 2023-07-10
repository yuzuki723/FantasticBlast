using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SabotageEffectDestroy : MonoBehaviour
{
    [SerializeField]
    [Tooltip("GoblinInstanceLine�N���X�̃C���X�^���X������")]
    private GoblinInstanceLine m_goblinInstanceLine;

    private int m_goblinCount; //�S�u�����̐��𐔂���
    private int m_mimicCount; //�~�~�b�N�̐��𐔂���
    private bool m_destroyFlg; //�G�t�F�N�g���폜�������𔻒f����t���O
    private ParticleSystem m_particleSystem;

    // Start is called before the first frame update
    private void Start()
    {
        m_goblinCount = 0;
        m_mimicCount = 0;
        m_destroyFlg = false;
        m_particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    private void Update()
    {
        //�S�u�����̐����擾���A�L�^����
        m_goblinCount = GameObject.FindGameObjectsWithTag("Goblin").Length;
        //�~�~�b�N�̐����擾���A�L�^����
        m_mimicCount = GameObject.FindGameObjectsWithTag("ChestMonster").Length;
        //�v���C���[�����C��(�~�~�b�N�A�S�u�������C���X�^���X�������ƂȂ��)���z���Ă��邩�𔻒f����t���O���擾���A�L�^����
        bool playerInvasionFlg = m_goblinInstanceLine.PlayerInvasionFlgProperty;

        if (m_destroyFlg == false) //���܂ŃG�t�F�N�g���폜����Ă��Ȃ������ꍇ
        {
            if (playerInvasionFlg == true && m_goblinCount <= 0 && m_mimicCount <= 0) //�S�u�����A�~�~�b�N�̂ǂ�������Ȃ��ꍇ
            {
                m_destroyFlg = true; //�G�t�F�N�g���폜�o����
                Color color = new Color32(255, 255, 255, 0);
                m_particleSystem.startColor = color;
                Destroy(this.gameObject, 3.5f); //3.5�b��ɃG�t�F�N�g���폜����
            }
        }
    }
}