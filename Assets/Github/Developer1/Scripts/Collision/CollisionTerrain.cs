using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTerrain : MonoBehaviour
{
    [SerializeField]
    [Tooltip("爆発エフェクトを入れる")]
    private GameObject m_explosion;

    [SerializeField]
    [Tooltip("爆発エフェクトを入れる")]
    private FireMagicDestroy m_fireMagicDestroy;

    private Vector3 m_bombPos; //爆弾の座標

    private void Update()
    {
        if (m_fireMagicDestroy.ToDoExpFlgProperty)
        {
            Instantiate(m_explosion, m_bombPos, Quaternion.identity); //爆発(エフェクト)をインスタンス化
            m_fireMagicDestroy.ToDoExpFlgProperty = false; //何度もif文に入ってこないようにする
        }
    }

    private void OnCollisionEnter(Collision _collision)
    {
        if (_collision.gameObject.tag == "Bomb") //Terrain(地面)に爆弾が衝突した場合
        {
            Destroy(_collision.gameObject, 2.0f); //2秒後に爆弾(火魔法)削除
        }
    }

    private void OnCollisionStay(Collision _collision)
    {
        if (_collision.gameObject.tag == "Bomb") //Terrain(地面)に爆弾が衝突した場合
        {
            //爆弾(火魔法)の座標を地面に当たり続けている間はずっと更新される
            m_bombPos = _collision.gameObject.transform.position; //爆弾(火魔法)の座標を記録する
        }
    }
}