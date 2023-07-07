using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMonsterCollider : MonoBehaviour
{
    //m_sphereColliderを外側で値を変えれるが、
    //このクラスではなぜか反映されない

    [SerializeField]
    [Tooltip("当たり判定を入れる")]
    private SphereCollider m_sphereCollider;

    //public SphereCollider m_sphereCollider;

    static bool m_attackColliderOnFlg; //攻撃アニメーション時の当たり判定のフラグ

    private void Start()
    {
        m_attackColliderOnFlg = false;
    }

    public bool AttackColliderOnFlgProperty //セッターとゲッター両方の役割がある関数
    {
        get { return m_attackColliderOnFlg; }
        set { m_attackColliderOnFlg = value; }
    }

    private void Update()
    {
        Debug.Log("現在のフラグの状態は" + m_sphereCollider.enabled + "です(ChestMonsterColliderクラス)");
    }

    public SphereCollider SphereColliderProperty //セッターとゲッター両方の役割がある関数
    {
        get { return m_sphereCollider; }
        set { m_sphereCollider = value; }
    }
}