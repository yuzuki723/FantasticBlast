using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1SceneFromHomeScene : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        //��Ƀv���C���[���X�e�[�W��I���������ɃV�[���؂�ւ�������
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("Stage1Scene");
        }
    }
}