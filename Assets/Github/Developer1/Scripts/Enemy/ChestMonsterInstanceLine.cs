using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMonsterInstanceLine : MonoBehaviour
{
    //敵用---------------------------------------------
    [SerializeField]
    [Tooltip("インスタンス化する敵を入れる")]
    private GameObject m_enemyInstance;

    [SerializeField]
    [Tooltip("1体目の敵をインスタンス化する基準となるオブジェクトを入れる")]
    private GameObject m_enemyStandardObject;

    private int m_enemyInstNumber; //敵をインスタンス化する数
    private int m_instanceCounter; //インスタンス化する敵の数を数える
    //敵をインスタンス化する座標
    Vector3 m_firstEnemyInstancePos;
    Vector3 m_secondEnemyInstancePos;
    Vector3 m_thirdEnemyInstancePos;
    //-------------------------------------------------

    //道を封鎖する妨害エフェクト用---------------------
    [SerializeField]
    [Tooltip("インスタンス化するエフェクトを入れる")]
    private GameObject m_effectInstance;

    [SerializeField]
    [Tooltip("エフェクトをインスタンス化する基準となるオブジェクトを入れる")]
    private GameObject m_effectStandardObject;

    Vector3 m_effectInstancePos;
    //-------------------------------------------------

    private void Start()
    {
        m_enemyInstNumber = 3;
        m_instanceCounter = 0;

        //3体の敵のインスタンス化する座標をずらす(固定位置)
        m_firstEnemyInstancePos = m_enemyStandardObject.gameObject.transform.position;
        m_secondEnemyInstancePos = m_firstEnemyInstancePos + new Vector3(-20f, 0f, 0f);
        m_thirdEnemyInstancePos = m_secondEnemyInstancePos + new Vector3(-20f, 0f, 0f);

        //エフェクトをインスタンス化する座標を記録する
        m_effectInstancePos = m_effectStandardObject.gameObject.transform.position;
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Player")) //当たり主がプレイヤーの場合
        {
            if (m_instanceCounter < m_enemyInstNumber) //m_enemyInstNumberに定義した数分だけしか敵をインスタンス化しない
            {
                for(; m_instanceCounter < m_enemyInstNumber; m_instanceCounter++)
                {
                    //ミミックのインスタンス化(それぞれ座標が異なる)
                    if (m_instanceCounter == 0)
                    {
                        EnemyInstance(m_firstEnemyInstancePos);
                    }
                    else
                    {
                        if(m_instanceCounter == 1)
                        {
                            EnemyInstance(m_secondEnemyInstancePos);
                        }
                        else
                        {
                            EnemyInstance(m_thirdEnemyInstancePos);
                        }
                    }
                }

                //エフェクトをインスタンス化
                Instantiate(m_effectInstance, m_effectInstancePos, m_effectInstance.transform.rotation);
            }
        }
    }

    private void EnemyInstance(Vector3 _instancePos)
    {
        Instantiate(m_enemyInstance, new Vector3(_instancePos.x, _instancePos.y, _instancePos.z), m_enemyInstance.transform.rotation);
    }
}