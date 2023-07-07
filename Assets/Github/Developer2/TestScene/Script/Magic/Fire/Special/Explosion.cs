using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    //�����̃A�b�Z�g
    [SerializeField] GameObject m_explosion;

    //��������܂ł̎���
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
                //��������܂ł̎��Ԃ����Z�b�g
                m_explosionTime = 5 * 60;

                //����������
                Instantiate(m_explosion, transform.position, Quaternion.identity);

                //���e������
                Destroy(this.gameObject);
        }
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        m_explosionFlg = true;
    }
}
