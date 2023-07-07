using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMonsterCollider : MonoBehaviour
{
    //m_sphereCollider���O���Œl��ς���邪�A
    //���̃N���X�ł͂Ȃ������f����Ȃ�

    [SerializeField]
    [Tooltip("�����蔻�������")]
    private SphereCollider m_sphereCollider;

    //public SphereCollider m_sphereCollider;

    static bool m_attackColliderOnFlg; //�U���A�j���[�V�������̓����蔻��̃t���O

    private void Start()
    {
        m_attackColliderOnFlg = false;
    }

    public bool AttackColliderOnFlgProperty //�Z�b�^�[�ƃQ�b�^�[�����̖���������֐�
    {
        get { return m_attackColliderOnFlg; }
        set { m_attackColliderOnFlg = value; }
    }

    private void Update()
    {
        Debug.Log("���݂̃t���O�̏�Ԃ�" + m_sphereCollider.enabled + "�ł�(ChestMonsterCollider�N���X)");
    }

    public SphereCollider SphereColliderProperty //�Z�b�^�[�ƃQ�b�^�[�����̖���������֐�
    {
        get { return m_sphereCollider; }
        set { m_sphereCollider = value; }
    }
}