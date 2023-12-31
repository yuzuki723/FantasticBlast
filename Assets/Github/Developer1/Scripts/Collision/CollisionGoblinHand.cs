using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionGoblinHand : MonoBehaviour
{
    public GoblinAttack m_goblinAttack;
    public GoblinSliderHPBer m_goblinSliderHPBer;

    [SerializeField]
    [Tooltip("当たり判定を入れる")]
    private SphereCollider m_sphereCollider;

    // Start is called before the first frame update
    private void Start()
    {
        //初期化時にfalseにするとなぜか当たり判定が
        //起きないのでひとまずtrueにする(現在そこまで影響なし)
        m_sphereCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Player"))
        {
            if (m_goblinAttack.HandColliderFlgProperty)
            {
                Debug.Log(m_goblinAttack.HandColliderFlgProperty);
                m_sphereCollider.enabled = true; //(こん棒部分の)当たり判定を有効
                //Invoke("ColliderReset", 0.5f); //0.5秒後に指定した関数を呼び出す
                m_goblinAttack.HandColliderFlgProperty = false;
            }
        }
    }

    private void Update()
    {
        if(m_goblinSliderHPBer.GoblinCurrentHPProperty <= 0) //ゴブリンのHPが無い場合
        {
            m_sphereCollider.enabled = false; //当たり判定を解除する
        }
    }

    //private void ColliderReset()
    //{
    //    m_sphereCollider.enabled = false; //(こん棒部分の)当たり判定を無効
    //    Debug.Log("こん棒の当たり判定を解除しました");
    //}
}