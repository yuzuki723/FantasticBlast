using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMonsterAnimationFlgSet : MonoBehaviour
{
    static bool m_attackOnFlg; //�U���A�j���[�V���������邩�𔻒f����t���O

    // Start is called before the first frame update
    private void Start()
    {
        m_attackOnFlg = false;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public bool AttackOnFlgProperty //�Z�b�^�[�ƃQ�b�^�[�����̖���������֐�
    {
        get { return m_attackOnFlg; }
        set { m_attackOnFlg = value; }
    }
}