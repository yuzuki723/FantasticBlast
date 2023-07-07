using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireShot : MonoBehaviour
{
    [SerializeField] GameObject m_fire;
    [SerializeField] GameObject m_appearancePlace;
    private Animator m_animator; //アニメーターコンポーネント取得用
    private int m_coolTime; //火魔法を撃ってから発生するクールタイム
    private float m_moveSpeed = 600;

    // Start is called before the first frame update
    private void Start()
    {
        m_appearancePlace = transform.GetChild(0).gameObject;
        m_animator = GetComponent<Animator>(); //アニメーターコンポーネントを取得
        m_coolTime = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        m_coolTime--;
        if (Input.GetMouseButtonDown(0) && m_coolTime <= 0)
        {
            GameObject ball = (GameObject)Instantiate(m_fire, m_appearancePlace.transform.position, Quaternion.identity);
            Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
            ballRigidbody.AddForce(transform.forward * m_moveSpeed);

            m_animator.SetBool("Attack", true); //魔法の杖のアタックアニメーションを開始する

            m_coolTime = 60 * 12; //クールタイムを設ける
        }
        else
        {
            m_animator.SetBool("Attack", false); //魔法の杖のアタックアニメーションを終了する
        }
    }
}