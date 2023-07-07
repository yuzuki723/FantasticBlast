using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicParent : MonoBehaviour
{
    //特殊魔法は発動していない
    private bool m_specialMagicFlg;

    //通常魔法は発動していない
    private bool m_standardMagicFlg;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //左クリックで通常魔法発動
            m_standardMagicFlg = true;
            return;
        }
        else
        {
            m_standardMagicFlg = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            //右クリックで特殊魔法発動
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
