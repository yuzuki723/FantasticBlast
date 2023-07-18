using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_StaffAnime : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("true");
            _animator.SetBool("Moving", true);
        }

    }
}
