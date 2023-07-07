using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIre_Standerd : MonoBehaviour
{

    private Animator m_animation;

    //魔法の発動時間
    private float m_magicInvocationTime = 7 * 60;

    void Start()
    {
        m_animation = GetComponent<Animator>();
    }


    void Update()
    {
        //魔法出現時間がなくなったら消滅アニメーションを開始する
        ControlMagicAppearanceTime();

    }

    //魔法出現時間制御
    void ControlMagicAppearanceTime()
    {
        if (--m_magicInvocationTime < 0)
        {
            m_magicInvocationTime = 5 * 60;

            //消滅アニメーションを開始
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
