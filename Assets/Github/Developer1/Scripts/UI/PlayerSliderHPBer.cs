using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSliderHPBer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("プレイヤーHPの初期値")]
    private int m_playerMaxHP;
    private int m_playerCurrentHP;

    [SerializeField]
    [Tooltip("スライダーを入れる")]
    private Slider m_slider;

    // Start is called before the first frame update
    private void Start()
    {
        m_slider.value = 1; //スライダーをマックスにする
        m_playerCurrentHP = m_playerMaxHP; //プレイヤーのHP設定
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("GoblinRightHand")) //当たったものがゴブリンの右手だった場合
        {
            int playerDamage = 50; //プレイヤーのダメージ量
            m_playerCurrentHP = m_playerCurrentHP - playerDamage;
            Debug.Log("ゴブリンによって" + playerDamage + "ダメージ受けた");
        }
        else
        {
            if (_other.CompareTag("Heart")) //当たったものがハートだった場合
            {
                int playerRecovery = 30; //プレイヤーのHP回復量
                m_playerCurrentHP = m_playerCurrentHP + playerRecovery;
                Debug.Log("プレイヤーは" + playerRecovery + "回復しました");
                Destroy(_other.gameObject); //不必要になったのでハートを削除する
            }
            else
            {
                if (_other.CompareTag("MimicTooth")) //当たったものがミミックだった場合
                {
                    int playerDamage = 40; //プレイヤーのダメージ量
                    m_playerCurrentHP = m_playerCurrentHP - playerDamage;
                    Debug.Log("ミミックによって" + playerDamage + "ダメージ受けた");
                }
            }
        }

        if (m_playerCurrentHP <= 0)
        {
            m_playerCurrentHP = 0;
        }

        //プレイヤーの最大HPにおける現在のHPをスライダーに反映させる
        m_slider.value = (float)m_playerCurrentHP / (float)m_playerMaxHP;
    }
}