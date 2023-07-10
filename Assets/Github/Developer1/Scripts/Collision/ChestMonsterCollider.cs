using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMonsterCollider : MonoBehaviour
{
    [SerializeField]
    [Tooltip("当たり判定を入れる")]
    private BoxCollider m_boxCollider;

    static bool m_attackColliderOnFlg; //攻撃アニメーション時の当たり判定のフラグ

    private void Start()
    {
        m_attackColliderOnFlg = false;
    }

    private void Update()
    {
        //攻撃の当たり判定をフラグで制御する
        if (m_attackColliderOnFlg)
        {
            m_boxCollider.enabled = true;
        }
        else
        {
            m_boxCollider.enabled = false;
        }

        Debug.Log("現在のフラグの状態は" + m_boxCollider.enabled + "です(ChestMonsterColliderクラス)");
    }

    public bool AttackColliderOnFlgProperty //セッターとゲッター両方の役割がある関数
    {
        get { return m_attackColliderOnFlg; }
        set { m_attackColliderOnFlg = value; }
    }
}