using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestMonsterAstonish : MonoBehaviour
{
    [SerializeField]
    [Tooltip("ChestMonsterNoticeableLine�N���X�̃C���X�^���X������")]
    private ChestMonsterNoticeableLine m_chestMonsterNoticeableLine;

    [SerializeField]
    [Tooltip("�L�����o�X������")]
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
            Debug.Log("Astonish�̃t���O�󋵂�" + m_animator.GetBool("Astonish") + "�ł�");
            m_animator.SetBool("Astonish", true);
            m_canvas.SetActive(true); //�L�����o�X��L���ɂ���
        }
    }
}