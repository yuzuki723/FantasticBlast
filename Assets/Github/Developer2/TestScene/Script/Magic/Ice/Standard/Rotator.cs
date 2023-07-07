using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float _rotateX;
    [SerializeField] float _rotateY;
    [SerializeField] float _rotateZ;

    void Update()
    {
        gameObject.transform.Rotate(new Vector3(_rotateX,_rotateY,_rotateZ)* Time.deltaTime); 
    }
}
