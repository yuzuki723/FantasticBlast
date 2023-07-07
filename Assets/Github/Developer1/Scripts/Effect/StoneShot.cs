using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneShot : MonoBehaviour
{
    [SerializeField] GameObject m_stone;
    [SerializeField] GameObject m_appearancePlace;

    private float m_moveSpeed = 700;

    // Start is called before the first frame update
    private void Start()
    {
        m_appearancePlace = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject ball = (GameObject)Instantiate(m_stone, m_appearancePlace.transform.position, Quaternion.identity);
            Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
            ballRigidbody.AddForce(transform.forward * m_moveSpeed);
        }
    }
}