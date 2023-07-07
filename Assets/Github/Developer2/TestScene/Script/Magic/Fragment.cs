using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// �I�u�W�F�N�g�����͂ɔ�юU�点�鏈�����܂Ƃ߂�
/// </summary>
public class Fragment : MonoBehaviour
{
    /// <summary>
    /// �j�Ђ̃X�e�[�^�X
    /// </summary>
    private FragmentStatus _fragmentStatus = new FragmentStatus();

    public class FragmentStatus
    {
        /// <summary>
        /// �j�󎞂̔j�Ѓv���n�u
        /// </summary>
        public GameObject Prefab;

        /// <summary>
        /// ��юU��j�Ђ̐�
        /// </summary>
        public float Number;

        /// <summary>
        /// ��юU��j�Ђ̑���
        /// </summary>
        public float Speed;

        /// <summary>
        /// ��юU��j�Ђ������鎞��
        /// </summary>
        public float DestroyTime;
    }

    /// <summary>
    /// �j�Ђ̃X�e�[�^�X���Z�b�g����
    /// </summary>
    /// <param name="prafab">�j�Ђ̃v���n�u</param>
    /// <param name="number">�o�����鐔</param>
    /// <param name="speed">�o�����鑬��</param>
    /// <param name="destroyTiem">�o������ǂ̂��炢�ŏ��ł��邩</param>
    public void SetFragmentStatus(GameObject prafab, float number, float speed, float destroyTiem)
    {
        _fragmentStatus.Prefab = prafab;
        _fragmentStatus.Number = number;
        _fragmentStatus.Speed = speed;
        _fragmentStatus.DestroyTime = destroyTiem;
    }

    /// <summary>
    /// ���͂ɔj�Ђ��܂��U�炷
    /// </summary>
    public void FlyAroundFragment()
    {
        // _fragmentNumber�̐��Ԃ�o������
        for (int i = 0; i < _fragmentStatus.Number; i++)
        {
            // �j�Ђ��C���X�^���X(�p�x�̓����_���ɐݒ�)
            GameObject fagment = Instantiate(_fragmentStatus.Prefab, transform.position, Random.rotation);

            // �����_���ȕ����x�N�g�����擾
            Vector3 randVec = Random.insideUnitSphere.normalized;

            // �����_���ȕ����ɔj�Ђ��΂�
            Rigidbody rigidbody = fagment.GetComponent<Rigidbody>();
            rigidbody.AddForce(randVec * _fragmentStatus.Speed, ForceMode.Impulse);

            // ���ԂɂȂ��������
            Destroy(fagment, _fragmentStatus.DestroyTime);
        }
    }
}



