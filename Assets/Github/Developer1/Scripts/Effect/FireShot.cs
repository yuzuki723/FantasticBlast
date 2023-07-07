using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireShot : MonoBehaviour
{
    [SerializeField] GameObject m_fire;
    [SerializeField] GameObject m_appearancePlace;
    private Animator m_animator; //�A�j���[�^�[�R���|�[�l���g�擾�p
    private int m_coolTime; //�Ζ��@�������Ă��甭������N�[���^�C��
    private float m_moveSpeed = 600;

    // Start is called before the first frame update
    private void Start()
    {
        m_appearancePlace = transform.GetChild(0).gameObject;
        m_animator = GetComponent<Animator>(); //�A�j���[�^�[�R���|�[�l���g���擾
        m_coolTime = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        m_coolTime--;
        if (Input.GetMouseButtonDown(0) && m_coolTime <= 0)
        {
            GameObject ball = (GameObject)Instantiate(m_fire, m_appearancePlace.transform.position, Quaternion.identity);
            Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
            ballRigidbody.AddForce(transform.forward * m_moveSpeed);

            m_animator.SetBool("Attack", true); //���@�̏�̃A�^�b�N�A�j���[�V�������J�n����

            m_coolTime = 60 * 12; //�N�[���^�C����݂���
        }
        else
        {
            m_animator.SetBool("Attack", false); //���@�̏�̃A�^�b�N�A�j���[�V�������I������
        }
    }
}