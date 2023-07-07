using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private TriggerEvent m_onTriggerStay = new TriggerEvent();
    [SerializeField] private TriggerEvent m_onTriggerExit = new TriggerEvent();

    //Is Trigger��ON�ő���Collider�Əd�Ȃ��Ă��鎞�́A���̃��\�b�h����ɌĂяo�����
    private void OnTriggerStay(Collider _other)
    {
        m_onTriggerStay.Invoke(_other); //m_onTriggerStay�Ŏw�肳�ꂽ���������s����
    }

    private void OnTriggerExit(Collider _other)
    {
        m_onTriggerExit.Invoke(_other); //m_onTriggerExit�Ŏw�肳�ꂽ���������s����
    }

    //[Serializable]��t���邱�Ƃ�Inspector���ł��̊֐���\���o����悤�ɂ���
    [Serializable] public class TriggerEvent : UnityEvent<Collider>
    {

    }
}