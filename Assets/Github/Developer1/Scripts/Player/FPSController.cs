using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    private float m_x, m_z;
    [SerializeField] float m_moveSpeed = 0.2f; //��l���̈ړ����x

    public GameObject m_camera;
    private Quaternion m_cameraRot, m_characterRot;
    private float m_xSensityvity = 3f, m_ySensityvity = 3f; //sensityvity(���x)

    private float m_jumpPower; //��l���̃W�����v�p
    private bool m_isJumping = false; //��l�����W�����v���Ă��邩�𔻒f����
    private Rigidbody m_rigidbody;

    private bool m_cursorLock = true; //�}�E�X�J�[�\������ʒ����ɌŒ肵�Ă��邩�𔻒f����
    private float m_camAngMaxX = 70f, m_camAngMinX = -70f; //�J�����p�x�̐���

    // Start is called before the first frame update
    private void Start()
    {
        m_cameraRot = m_camera.transform.localRotation; //�J�����̃��[�J��������
        m_characterRot = transform.localRotation; //��l���̃��[�J��������

        //m_jumpPower = 10f;
        m_jumpPower = 0f;

        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        float cameraXRot = Input.GetAxis("Mouse X") * m_ySensityvity;
        float cameraYRot = Input.GetAxis("Mouse Y") * m_xSensityvity;

        m_cameraRot *= Quaternion.Euler(-cameraYRot, 0, 0);
        m_characterRot *= Quaternion.Euler(0, cameraXRot, 0);

        m_cameraRot = ClampRotation(m_cameraRot);

        m_camera.transform.localRotation = m_cameraRot;
        transform.localRotation = m_characterRot;

        if (Input.GetKeyDown(KeyCode.Space) && !m_isJumping)
        {
            m_rigidbody.velocity = Vector3.up * m_jumpPower;
            m_isJumping = true;
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            m_isJumping = false;
        }

        UpdateCursorLock();
    }

    private void FixedUpdate()
    {
        m_x = 0;
        m_z = 0;

        m_x = Input.GetAxisRaw("Horizontal") * m_moveSpeed;
        m_z = Input.GetAxisRaw("Vertical") * m_moveSpeed;

        Vector3 camForward = m_camera.transform.forward;
        camForward.y = 0; //������Ɉړ����Ȃ��悤�ɂ���
        transform.position += camForward * m_z + m_camera.transform.right * m_x;
    }

    private void OnCollisionEnter(Collision _collision)
    {
        if(_collision.gameObject.CompareTag("Terrain"))
        {
            m_isJumping = false;
        }
    }

    public void UpdateCursorLock()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            m_cursorLock = false;
        }
        else
        {
            if(Input.GetMouseButton(0))
            {
                m_cursorLock = true;
            }
        }

        if(m_cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            if(!m_cursorLock)
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public Quaternion ClampRotation(Quaternion _quaternion)
    {
        _quaternion.x /= _quaternion.w;
        _quaternion.y /= _quaternion.w;
        _quaternion.z /= _quaternion.w;
        _quaternion.w = 1f;

        float angleX = Mathf.Atan(_quaternion.x) * Mathf.Rad2Deg * 2f;
        angleX = Mathf.Clamp(angleX,m_camAngMinX,m_camAngMaxX);
        _quaternion.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return _quaternion;
    }
}