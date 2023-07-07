using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMonsterAstonish : MonoBehaviour
{
    [SerializeField]
    [Tooltip("ChestMonsterNoticeableLine�N���X�̃C���X�^���X������")]
    private ChestMonsterNoticeableLine m_chestMonsterNoticeableLine;

    //private bool m_crossedTheLineFlg; //crossed the line == ���C��(ChestMonsterNoticeableLine)���z����

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
        Debug.Log("Astonish�̃t���O�󋵂�" + m_animator.GetBool("Astonish") + "�ł�");
        m_animator.SetBool("Astonish", true);

        //if (m_chestMonsterNoticeableLine.CrossedTheLineFlgProperty == true)
        //{
        //�v���C���[����������A�j���[�V�������J�n����
        //m_animator.SetBool("Astonish", true);
        //Debug.Log("���݂̃~�~�b�N�̃t���O��" + m_animator.GetBool("Astonish") + "�ł�");
        //m_chestMonsterNoticeableLine.CrossedTheLineFlgProperty = false;
        //}
        //else
        //{
        //Debug.Log("���݂̃~�~�b�N�̃t���O��" + m_animator.GetBool("Astonish") + "�ł�");
        //}
    }
}