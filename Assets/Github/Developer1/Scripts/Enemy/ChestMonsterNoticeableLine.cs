using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChestMonsterNoticeableLine : MonoBehaviour
{
    static bool m_crossedTheLineFlg; //crossed the line == ライン(ChestMonsterNoticeableLine)を越えた

    private void Start()
    {
        m_crossedTheLineFlg = false;
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (m_crossedTheLineFlg == false)
        {
            Debug.Log("入りました");

            if (_other.CompareTag("Player"))
            {
                Debug.Log("プレイヤーを検知しました");
                m_crossedTheLineFlg = true;
            }
        }
    }

    public bool CrossedTheLineFlgProperty //セッターとゲッター両方の役割がある関数
    {
        get { return m_crossedTheLineFlg; }
        set { m_crossedTheLineFlg = value; }
    }
}