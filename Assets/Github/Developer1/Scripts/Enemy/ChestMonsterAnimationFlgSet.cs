using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMonsterAnimationFlgSet : MonoBehaviour
{
    static bool m_doNotMoveFlg; //�~�~�b�N��Idle�A�j���[�V���������Ă��鎞�ł��ړ����Ȃ��悤�ɐ��䂷��t���O

    // Start is called before the first frame update
    private void Start()
    {
        m_doNotMoveFlg = false;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public bool DoNotMoveFlgProperty //�Z�b�^�[�ƃQ�b�^�[�����̖���������֐�
    {
        get { return m_doNotMoveFlg; }
        set { m_doNotMoveFlg = value; }
    }
}