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

    //Is TriggerがONで他のColliderと重なっている時は、このメソッドが常に呼び出される
    private void OnTriggerStay(Collider _other)
    {
        m_onTriggerStay.Invoke(_other); //m_onTriggerStayで指定された処理を実行する
    }

    private void OnTriggerExit(Collider _other)
    {
        m_onTriggerExit.Invoke(_other); //m_onTriggerExitで指定された処理を実行する
    }

    //[Serializable]を付けることでInspector側でこの関数を表示出来るようにする
    [Serializable] public class TriggerEvent : UnityEvent<Collider>
    {

    }
}