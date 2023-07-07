using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionGoblinHand : MonoBehaviour
{
    public GoblinAttack m_goblinAttack;
    public GoblinSliderHPBer m_goblinSliderHPBer;

    [SerializeField]
    [Tooltip("�����蔻�������")]
    private SphereCollider m_sphereCollider;

    // Start is called before the first frame update
    private void Start()
    {
        //����������false�ɂ���ƂȂ��������蔻�肪
        //�N���Ȃ��̂łЂƂ܂�true�ɂ���(���݂����܂ŉe���Ȃ�)
        m_sphereCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Player"))
        {
            if (m_goblinAttack.HandColliderFlgProperty)
            {
                Debug.Log(m_goblinAttack.HandColliderFlgProperty);
                m_sphereCollider.enabled = true; //(����_������)�����蔻���L��
                //Invoke("ColliderReset", 0.5f); //0.5�b��Ɏw�肵���֐����Ăяo��
                m_goblinAttack.HandColliderFlgProperty = false;
            }
        }
    }

    private void Update()
    {
        if(m_goblinSliderHPBer.GoblinCurrentHPProperty <= 0) //�S�u������HP�������ꍇ
        {
            m_sphereCollider.enabled = false; //�����蔻�����������
        }
    }

    //private void ColliderReset()
    //{
    //    m_sphereCollider.enabled = false; //(����_������)�����蔻��𖳌�
    //    Debug.Log("����_�̓����蔻����������܂���");
    //}
}