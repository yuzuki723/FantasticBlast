using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 移動に合わせて杖を揺らすクラス
/// </summary>
public class StaffMoving : MonoBehaviour
{
    [SerializeField, Tooltip("杖のプレハブ")]
    private GameObject _staffPrefab;

    [SerializeField, Tooltip("カメラ")]
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
