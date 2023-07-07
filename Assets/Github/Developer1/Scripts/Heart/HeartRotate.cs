using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRotate : MonoBehaviour
{
    [SerializeField]
    [Tooltip("ハート(回復アイテム)を回転させる速度")]
    private float m_heartRotateSpeed;

    // Start is called before the first frame update
    private void Start()
    {
        transform.Rotate(-90f, 0f, 0f); //ハートの初期角度を設定
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(0f, 0f, m_heartRotateSpeed);
    }
}