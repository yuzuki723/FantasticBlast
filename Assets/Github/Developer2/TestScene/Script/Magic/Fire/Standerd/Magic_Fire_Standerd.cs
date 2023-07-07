using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_Fire_Standerd : MonoBehaviour
{

    private MagicParent m_magic;

    [SerializeField] GameObject m_fire_Standerd;
    [SerializeField] GameObject m_appearancePlace;

    //魔法の速さ
    private float m_magicSpeed;

    void Start()
    {
        m_magic = GetComponent<MagicParent>();

        m_appearancePlace = transform.GetChild(0).gameObject;

        m_magicSpeed = 100;

    }

    public void ShotMagic()
    {
        //右クリックが押させていなかったら早期リターン
        if (m_magic.IsStandardMagicFlg() != true) return;

        Quaternion.Euler(-90, 0, 0);

        Quaternion quaternion = transform.root.rotation;

        //魔法が出現
        GameObject magic = (GameObject)Instantiate(m_fire_Standerd, m_appearancePlace.transform.position, transform.root.rotation);
        Rigidbody rigidbody = magic.GetComponent<Rigidbody>();

        //プレイヤーの正面に飛ばす
        rigidbody.AddForce(transform.root.forward * m_magicSpeed,ForceMode.Acceleration);

    }

    public Quaternion GetCaneRotate()
    {
        return transform.root.rotation;
    }
}
