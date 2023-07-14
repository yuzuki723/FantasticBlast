using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// �ړ��ɍ��킹�ď��h�炷�N���X
/// </summary>
public class StaffMoving : MonoBehaviour
{
    [SerializeField, Tooltip("��̃v���n�u")]
    private GameObject _staffPrefab;

    [SerializeField, Tooltip("�J����")]
    private Camera _camera;

    [SerializeField] private CurveControlledBob _staffBob = new CurveControlledBob();

    private void Start()
    {
        _staffBob.Setup(_camera, 10);
    }

    private void Update()
    {
        Vector3 staffBob = _staffBob.DoHeadBob(0.2f);
        _staffPrefab.transform.localPosition = staffBob;
        Debug.Log(staffBob);
    }

}
