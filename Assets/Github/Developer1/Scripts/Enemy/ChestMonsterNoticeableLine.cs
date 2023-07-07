using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChestMonsterNoticeableLine : MonoBehaviour
{
    static bool m_crossedTheLineFlg; //crossed the line == ���C��(ChestMonsterNoticeableLine)���z����

    private void Start()
    {
        m_crossedTheLineFlg = false;
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (m_crossedTheLineFlg == false)
        {
            Debug.Log("����܂���");

            if (_other.CompareTag("Player"))
            {
                Debug.Log("�v���C���[�����m���܂���");
                m_crossedTheLineFlg = true;
            }
        }
    }

    public bool CrossedTheLineFlgProperty //�Z�b�^�[�ƃQ�b�^�[�����̖���������֐�
    {
        get { return m_crossedTheLineFlg; }
        set { m_crossedTheLineFlg = value; }
    }
}