using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        //Debug.Log("�������폜����܂�");
        Destroy(this.gameObject, 2.0f);
    }
}