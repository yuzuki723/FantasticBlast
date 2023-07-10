using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinInstanceLine : MonoBehaviour
{
    [SerializeField]
    [Tooltip("インスタンス化する敵を入れる")]
    private GameObject m_enemyInstance;

    [SerializeField]
    [Tooltip("敵をインスタンス化する範囲Aを入れる")]
    private Transform m_instanceRangeA;

    [SerializeField]
    [Tooltip("敵をインスタンス化する範囲Bを入れる")]
    private Transform m_instanceRangeB;

    [SerializeField]
    [Tooltip("インスタンス化する敵の数を入れる")]
    private int m_enemyInstNumber;

    private int m_enemyInstanceCounter; //インスタンス化する敵の数を数える
    static bool m_playerInvasionFlg; //プレイヤーがラインを越えたかを判断するフラグ

    private void Start()
    {
        m_enemyInstanceCounter = 0;
        m_playerInvasionFlg = false;
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Player")) //当たり主がプレイヤーの場合
        {
            if (m_enemyInstanceCounter < m_enemyInstNumber) //m_enemyInstNumberに定義した数分だけしか敵をインスタンス化しない
            {
                for (; m_enemyInstanceCounter < m_enemyInstNumber; m_enemyInstanceCounter++)
                {
                    //敵をXYZランダムな位置にインスタンス化する
                    float instancePosX = Random.Range(m_instanceRangeA.position.x, m_instanceRangeB.position.x);
                    float instancePosY = Random.Range(m_instanceRangeA.position.y, m_instanceRangeB.position.y);
                    float instancePosZ = Random.Range(m_instanceRangeA.position.z, m_instanceRangeB.position.z);

                    Instantiate(m_enemyInstance, new Vector3(instancePosX, instancePosY, instancePosZ), m_enemyInstance.transform.rotation);
                }
            }

            m_playerInvasionFlg = true; //プレイヤーがラインを越えた
        }
    }
    
    public bool PlayerInvasionFlgProperty //セッターとゲッター両方の役割がある関数
    {
        get { return m_playerInvasionFlg; }
        set { m_playerInvasionFlg = value; }
    }
}