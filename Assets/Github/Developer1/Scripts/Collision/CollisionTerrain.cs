using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTerrain : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�����G�t�F�N�g������")]
    private GameObject m_explosion;

    [SerializeField]
    [Tooltip("�����G�t�F�N�g������")]
    private FireMagicDestroy m_fireMagicDestroy;

    private Vector3 m_bombPos; //���e�̍��W

    private void Update()
    {
        if (m_fireMagicDestroy.ToDoExpFlgProperty)
        {
            Instantiate(m_explosion, m_bombPos, Quaternion.identity); //����(�G�t�F�N�g)���C���X�^���X��
            m_fireMagicDestroy.ToDoExpFlgProperty = false; //���x��if���ɓ����Ă��Ȃ��悤�ɂ���
        }
    }

    private void OnCollisionEnter(Collision _collision)
    {
        if (_collision.gameObject.tag == "Bomb") //Terrain(�n��)�ɔ��e���Փ˂����ꍇ
        {
            Destroy(_collision.gameObject, 2.0f); //2�b��ɔ��e(�Ζ��@)�폜
        }
    }

    private void OnCollisionStay(Collision _collision)
    {
        if (_collision.gameObject.tag == "Bomb") //Terrain(�n��)�ɔ��e���Փ˂����ꍇ
        {
            //���e(�Ζ��@)�̍��W��n�ʂɓ����葱���Ă���Ԃ͂����ƍX�V�����
            m_bombPos = _collision.gameObject.transform.position; //���e(�Ζ��@)�̍��W���L�^����
        }
    }
}