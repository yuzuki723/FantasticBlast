using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstanceEffect : MonoBehaviour
{
    [SerializeField]
    [Tooltip("インスタンス化するエフェクトを入れる")]
    private GameObject m_instanceEffect;

    [SerializeField]
    [Tooltip("エフェクトを消す時間を入れる")]
    private float m_deleteTime;

    // Start is called before the first frame update
    private void Start()
    {
        GameObject instanceEffect = Instantiate(m_instanceEffect, transform.position, Quaternion.identity);
        Destroy(instanceEffect, m_deleteTime);
    }
}