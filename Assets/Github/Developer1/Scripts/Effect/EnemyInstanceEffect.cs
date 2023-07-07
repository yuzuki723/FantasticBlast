using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstanceEffect : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�C���X�^���X������G�t�F�N�g������")]
    private GameObject m_instanceEffect;

    [SerializeField]
    [Tooltip("�G�t�F�N�g���������Ԃ�����")]
    private float m_deleteTime;

    // Start is called before the first frame update
    private void Start()
    {
        GameObject instanceEffect = Instantiate(m_instanceEffect, transform.position, Quaternion.identity);
        Destroy(instanceEffect, m_deleteTime);
    }
}