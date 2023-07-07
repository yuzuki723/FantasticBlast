using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    //爆風のアッセト
    [SerializeField] GameObject m_explosion;

    //爆発するまでの時間
    private float m_explosionTime = 5 * 60;

    private bool m_explosionFlg = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (m_explosionFlg)
        {
            m_explosionTime--;
            if (m_explosionTime < 0)
            {
                //爆発するまでの時間をリセット
                m_explosionTime = 5 * 60;

                //爆発させる
                Instantiate(m_explosion, transform.position, Quaternion.identity);

                //爆弾を消す
                Destroy(this.gameObject);
        }
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        m_explosionFlg = true;
    }
}
