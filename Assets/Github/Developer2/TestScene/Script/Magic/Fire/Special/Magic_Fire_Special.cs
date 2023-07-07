using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_Fire_Special : MonoBehaviour
{

    private MagicParent m_magic;

    [SerializeField] GameObject m_fire_Special;
    [SerializeField] GameObject m_appearancePlace;


    //アニメーターコンポーネント取得用
    private Animator m_animator;

    //魔法発動のクールタイム
    int m_magicCoolTime;

    private float m_moveSpeed = 600;

    void Start()
    {
        m_magic = GetComponent<MagicParent>();

        m_appearancePlace = transform.GetChild(0).gameObject;
        m_animator = GetComponent<Animator>(); //アニメーターコンポーネントを取得
        m_magicCoolTime = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        //クールタイムの減らす
        DecreaseMagicCoolTime();

        if(m_magicCoolTime == 0)
        {
            ShotMagic();
        }
        else
        {
            m_animator.SetBool("Attack", false);
        }
    }

    //クールタイム減少
    private void DecreaseMagicCoolTime()
    {
        --m_magicCoolTime;

        //0より小さくしない
        if(m_magicCoolTime < 0)
        {
            m_magicCoolTime = 0;
        }
    }

    //魔法発動
    private void ShotMagic()
    {
        //右クリックが押させていなかったら早期リターン
        if (m_magic.IsSpecialMagicFlg() != true) return;

        //魔法が出現
        GameObject ball = (GameObject)Instantiate(m_fire_Special, m_appearancePlace.transform.position, Quaternion.identity);
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();

        //プレイヤーの正面に飛ばす
        ballRigidbody.AddForce(transform.forward * m_moveSpeed);

        m_animator.SetBool("Attack", true); //魔法の杖のアタックアニメーションを開始する

        m_magicCoolTime = 60 * 12; //クールタイムを設ける
    }
}
