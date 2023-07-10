using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class GoblinMove : MonoBehaviour
{
    //ゴブリンの色を変える
    //出現する際、透明からだんだんと不透明になって出てくる

    public GoblinSliderHPBer m_goblinSliderHPBer;
    private Animator m_animator;
    private NavMeshAgent m_agent;

    // Start is called before the first frame update
    private void Start()
    {
        m_agent = GetComponent<NavMeshAgent>(); //コンポーネントを取得
        m_animator = GetComponent<Animator>(); //アニメーターコンポーネントを取得
    }

    private void Update()
    {
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);
        //}
        //else
        //{
        //    GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
        //}
    }

    //プレイヤーを探知した時に実行する関数
    public void OnDetectObject(Collider _collider)
    {
        Debug.Log("ゴブリンは正常です");
        //検知したオブジェクトに「Player」のタグが付いていれば、そのオブジェクトを追いかける
        if (_collider.CompareTag("Player"))
        {
            m_agent.destination = _collider.transform.position;
            m_animator.SetBool("Move", true); //追尾アニメーションを開始する

            if (m_goblinSliderHPBer.m_goblinCurrentHP <= 0)
            {
                m_agent.isStopped = true; //ゴブリンの動きを止める
            }
            else
            {
                m_agent.isStopped = false; //ゴブリンが動く
            }
        }
    }

    //探知範囲からプレイヤーが消えた時に実行する関数
    public void NotDetectObject(Collider _collider)
    {
        //検知したオブジェクトに「Player」のタグが付いていれば、そのオブジェクトを追いかける
        if (_collider.CompareTag("Player"))
        {
            m_agent.destination = _collider.transform.position;
            m_animator.SetBool("Move", false); //追尾アニメーションを終了する
            m_agent.isStopped = true; //ゴブリンの動きを止める
            m_agent.velocity = Vector3.zero;
        }
    }
}