using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMagicDestroy : MonoBehaviour
{
    static bool m_toDoExpFlg; //爆弾が爆発するかを判断するフラグ

    private void Start()
    {
        m_toDoExpFlg = false;
    }

    private void Update()
    {
        //Debug.Log(m_toDoExpFlg + "です");
    }

    public void OnDestroy() //オブジェクトが消えた瞬間に呼び出される関数
    {
        if (m_toDoExpFlg == false)
        {
            m_toDoExpFlg = true; //爆発出来る
        }
    }

    public bool ToDoExpFlgProperty //セッターとゲッター両方の役割がある関数
    {
        get { return m_toDoExpFlg; }
        set { m_toDoExpFlg = value; }   
    }
}