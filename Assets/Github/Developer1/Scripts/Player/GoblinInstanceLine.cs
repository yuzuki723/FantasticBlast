using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinInstanceLine : MonoBehaviour
{
    [SerializeField]
    [Tooltip("インスタンス化する敵")]
    private GameObject m_enemyInstance;

    [SerializeField]
    [Tooltip("敵をインスタンス化する範囲A")]
    private Transform m_instanceRangeA;

    [SerializeField]
    [Tooltip("敵をインスタンス化する範囲B")]
    private Transform m_instanceRangeB;

    [SerializeField]
    [Tooltip("インスタンス化する敵の数")]
    private int m_enemyInstNumber;

    private int m_instanceCounter = 0; //インスタンス化する敵の数を数える

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Player")) //当たり主がプレイヤーの場合
        {
            if (m_instanceCounter < m_enemyInstNumber) //m_enemyInstNumberに定義した数分だけしか敵をインスタンス化しない
            {
                for (; m_instanceCounter < m_enemyInstNumber; m_instanceCounter++)
                {
                    //敵をXYZランダムな位置にインスタンス化する
                    float instancePosX = Random.Range(m_instanceRangeA.position.x, m_instanceRangeB.position.x);
                    float instancePosY = Random.Range(m_instanceRangeA.position.y, m_instanceRangeB.position.y);
                    float instancePosZ = Random.Range(m_instanceRangeA.position.z, m_instanceRangeB.position.z);

                    Instantiate(m_enemyInstance, new Vector3(instancePosX, instancePosY, instancePosZ), m_enemyInstance.transform.rotation);
                }
            }
        }
    }
}