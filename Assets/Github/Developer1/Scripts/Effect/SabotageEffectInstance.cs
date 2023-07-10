using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabotageEffectInstance : MonoBehaviour
{
    [SerializeField]
    [Tooltip("インスタンス化するエフェクトを入れる")]
    private GameObject m_effectInstance;

    [SerializeField]
    [Tooltip("エフェクトをインスタンス化する基準となるオブジェクトを入れる")]
    private GameObject m_standardObject;

    private Vector3 m_effectInstancePos; //エフェクトをインスタンス化する座標
    static bool m_playerInvasionFlg; //プレイヤーがラインを越えたかを判断するフラグ

    // Start is called before the first frame update
    private void Start()
    {
        //エフェクトをインスタンス化する座標を記録する
        m_effectInstancePos = m_standardObject.gameObject.transform.position;
        m_playerInvasionFlg = false;
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (m_playerInvasionFlg == false && _other.CompareTag("Player")) //当たり主がプレイヤーの場合
        {
            //エフェクトをインスタンス化
            Instantiate(m_effectInstance, m_effectInstancePos, m_effectInstance.transform.rotation);
            m_playerInvasionFlg = true; //プレイヤーがラインを越えた
        }
    }
}