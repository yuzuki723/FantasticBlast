using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestMonsterAstonish : MonoBehaviour
{
    [SerializeField]
    [Tooltip("ChestMonsterNoticeableLineクラスのインスタンスを入れる")]
    private ChestMonsterNoticeableLine m_chestMonsterNoticeableLine;

    [SerializeField]
    [Tooltip("キャンバスを入れる")]
    private GameObject m_canvas;

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
            Debug.Log("Astonishのフラグ状況は" + m_animator.GetBool("Astonish") + "です");
            m_animator.SetBool("Astonish", true);
            m_canvas.SetActive(true); //キャンバスを有効にする
        }
    }
}