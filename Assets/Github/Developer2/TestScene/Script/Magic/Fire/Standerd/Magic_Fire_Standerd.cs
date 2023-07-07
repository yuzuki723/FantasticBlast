using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_Fire_Standerd : MonoBehaviour
{

    private MagicParent m_magic;

    [SerializeField] GameObject m_fire_Standerd;
    [SerializeField] GameObject m_appearancePlace;

    //���@�̑���
    private float m_magicSpeed;

    void Start()
    {
        m_magic = GetComponent<MagicParent>();

        m_appearancePlace = transform.GetChild(0).gameObject;

        m_magicSpeed = 100;

    }
    
    public void ShotMagic()
    {
        //�E�N���b�N���������Ă��Ȃ������瑁�����^�[��
        if (m_magic.IsStandardMagicFlg() != true) return;

        Quaternion.Euler(-90, 0, 0);

        Quaternion quaternion = transform.root.rotation;

        //���@���o��
        GameObject magic = (GameObject)Instantiate(m_fire_Standerd, m_appearancePlace.transform.position, transform.root.rotation);
        Rigidbody rigidbody = magic.GetComponent<Rigidbody>();

        //�v���C���[�̐��ʂɔ�΂�
        rigidbody.AddForce(transform.root.forward * m_magicSpeed,ForceMode.Acceleration);

    }

    public Quaternion GetCaneRotate()
    {
        return transform.root.rotation;
    }
}
