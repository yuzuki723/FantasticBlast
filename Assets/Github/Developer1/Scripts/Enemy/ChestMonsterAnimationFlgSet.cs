using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMonsterAnimationFlgSet : MonoBehaviour
{
    static bool m_attackOnFlg; //攻撃アニメーションをするかを判断するフラグ

    // Start is called before the first frame update
    private void Start()
    {
        m_attackOnFlg = false;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public bool AttackOnFlgProperty //セッターとゲッター両方の役割がある関数
    {
        get { return m_attackOnFlg; }
        set { m_attackOnFlg = value; }
    }
}