using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMonsterCollider : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�����蔻�������")]
    private BoxCollider m_boxCollider;

    static bool m_attackColliderOnFlg; //�U���A�j���[�V�������̓����蔻��̃t���O

    private void Start()
    {
        m_attackColliderOnFlg = false;
    }

    private void Update()
    {
        //�U���̓����蔻����t���O�Ő��䂷��
        if (m_attackColliderOnFlg)
        {
            m_boxCollider.enabled = true;
        }
        else
        {
            m_boxCollider.enabled = false;
        }

        Debug.Log("���݂̃t���O�̏�Ԃ�" + m_boxCollider.enabled + "�ł�(ChestMonsterCollider�N���X)");
    }

    public bool AttackColliderOnFlgProperty //�Z�b�^�[�ƃQ�b�^�[�����̖���������֐�
    {
        get { return m_attackColliderOnFlg; }
        set { m_attackColliderOnFlg = value; }
    }
}