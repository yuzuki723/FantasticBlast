using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMonsterAstonish : MonoBehaviour
{
    [SerializeField]
    [Tooltip("ChestMonsterNoticeableLineクラスのインスタンスを入れる")]
    private ChestMonsterNoticeableLine m_chestMonsterNoticeableLine;

    //private bool m_crossedTheLineFlg; //crossed the line == ライン(ChestMonsterNoticeableLine)を越えた

    private Animator m_animator;

    // Start is called before the first frame update
    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (m_chestMonsterNoticeableLine.CrossedTheLineFlgProperty == true)
        {
            BeginToMove();
        }
    }

    public void BeginToMove()
    {
        Debug.Log("Astonishのフラグ状況は" + m_animator.GetBool("Astonish") + "です");
        m_animator.SetBool("Astonish", true);

        //if (m_chestMonsterNoticeableLine.CrossedTheLineFlgProperty == true)
        //{
        //プレイヤーを驚かせるアニメーションを開始する
        //m_animator.SetBool("Astonish", true);
        //Debug.Log("現在のミミックのフラグは" + m_animator.GetBool("Astonish") + "です");
        //m_chestMonsterNoticeableLine.CrossedTheLineFlgProperty = false;
        //}
        //else
        //{
        //Debug.Log("現在のミミックのフラグは" + m_animator.GetBool("Astonish") + "です");
        //}
    }
}