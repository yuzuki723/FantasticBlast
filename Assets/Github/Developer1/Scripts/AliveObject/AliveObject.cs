using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveObject : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}