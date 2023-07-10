using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInstanceLine : MonoBehaviour
{
    [SerializeField]
    [Tooltip("ボスを入れる")]
    private GameObject m_boss;

    [SerializeField]
    [Tooltip("エフェクトを入れる")]
    private GameObject m_bossAppearanceEffect;

    [SerializeField]
    [Tooltip("エフェクトとボスをインスタンス化する基準となるオブジェクトを入れる")]
    private GameObject m_standardObject;

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Player")) //当たり主がプレイヤーの場合
        {
            //エフェクトをインスタンス化する
            Instantiate(m_bossAppearanceEffect, m_standardObject.transform.position + new Vector3(0, 10, 0), m_bossAppearanceEffect.transform.rotation);
            Invoke("BossInstance", 1f); //1秒後にBossInstance関数を呼び出す
        }
    }

    private void BossInstance()
    {
        Instantiate(m_boss, m_standardObject.transform.position + new Vector3(0, 0, -5), m_boss.transform.rotation);
    }
}