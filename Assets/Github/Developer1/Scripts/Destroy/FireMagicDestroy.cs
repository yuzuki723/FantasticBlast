using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMagicDestroy : MonoBehaviour
{
    static bool m_toDoExpFlg; //���e���������邩�𔻒f����t���O

    private void Start()
    {
        m_toDoExpFlg = false;
    }

    private void Update()
    {
        //Debug.Log(m_toDoExpFlg + "�ł�");
    }

    public void OnDestroy() //�I�u�W�F�N�g���������u�ԂɌĂяo�����֐�
    {
        if (m_toDoExpFlg == false)
        {
            m_toDoExpFlg = true; //�����o����
        }
    }

    public bool ToDoExpFlgProperty //�Z�b�^�[�ƃQ�b�^�[�����̖���������֐�
    {
        get { return m_toDoExpFlg; }
        set { m_toDoExpFlg = value; }   
    }
}