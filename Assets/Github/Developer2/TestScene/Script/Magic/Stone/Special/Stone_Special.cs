using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_Special : MonoBehaviour
{
    private float _appearanceHigh = 2.0f;

    private Shake _shake;

    [SerializeField,Tooltip("振動する時間")]
    private float _duration = 3;

    [SerializeField,Tooltip("揺れの強さ")]
    private float _strength = 10;



    void Start()
    {
        _shake = GetComponent<Shake>();
        _shake.StartShake(transform.position,_duration,_strength);
    }

    void Update()
    {
        if (_appearanceHigh >= 0)
        {
            transform.position += new Vector3(0,0.01f,0);
            _appearanceHigh -= 0.01f;
        } 
    }
}
