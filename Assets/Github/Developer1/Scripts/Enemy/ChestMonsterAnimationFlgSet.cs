using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMonsterAnimationFlgSet : MonoBehaviour
{
    static bool m_doNotMoveFlg; //ミミックがIdleアニメーションをしている時でも移動しないように制御するフラグ

    // Start is called before the first frame update
    private void Start()
    {
        m_doNotMoveFlg = false;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public bool DoNotMoveFlgProperty //セッターとゲッター両方の役割がある関数
    {
        get { return m_doNotMoveFlg; }
        set { m_doNotMoveFlg = value; }
    }
}