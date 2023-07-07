using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicParent : MonoBehaviour
{
    //���ꖂ�@�͔������Ă��Ȃ�
    private bool m_specialMagicFlg;

    //�ʏ햂�@�͔������Ă��Ȃ�
    private bool m_standardMagicFlg;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //���N���b�N�Œʏ햂�@����
            m_standardMagicFlg = true;
            return;
        }
        else
        {
            m_standardMagicFlg = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            //�E�N���b�N�œ��ꖂ�@����
            m_specialMagicFlg = true;
            return;
        }
        else
        {
            m_specialMagicFlg = false;
        }
    }

    public bool IsStandardMagicFlg()
    { 
        return m_standardMagicFlg;
    }

    public bool IsSpecialMagicFlg()
    { 
        return m_specialMagicFlg;
    }
}
