using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRotate : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�n�[�g(�񕜃A�C�e��)����]�����鑬�x")]
    private float m_heartRotateSpeed;

    // Start is called before the first frame update
    private void Start()
    {
        transform.Rotate(-90f, 0f, 0f); //�n�[�g�̏����p�x��ݒ�
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(0f, 0f, m_heartRotateSpeed);
    }
}