using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIre_Standerd : MonoBehaviour
{

    private Animator m_animation;

    //���@�̔�������
    private float m_magicInvocationTime = 7 * 60;

    void Start()
    {
        m_animation = GetComponent<Animator>();
    }


    void Update()
    {
        //���@�o�����Ԃ��Ȃ��Ȃ�������ŃA�j���[�V�������J�n����
        ControlMagicAppearanceTime();

    }

    //���@�o�����Ԑ���
    void ControlMagicAppearanceTime()
    {
        if (--m_magicInvocationTime < 0)
        {
            m_magicInvocationTime = 5 * 60;

            //���ŃA�j���[�V�������J�n
            m_animation.SetBool("Annihilation", true);
        }
    }

    void SelfDelete()
    {
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
