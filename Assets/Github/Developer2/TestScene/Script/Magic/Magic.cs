using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    /// <summary>
    /// ���@���ꂼ��̃_���[�W�ʂ������
    /// </summary>
    [SerializeField] public float _magicDamage;

    /// <summary>
    /// ���@�̃_���[�W�ʂ��Q�Ƃ���
    /// </summary>
    public float GetMagicDamage
    {
        get { return _magicDamage; }
    }
}
