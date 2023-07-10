using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SabotageEffectDestroy : MonoBehaviour
{
    [SerializeField]
    [Tooltip("GoblinInstanceLineクラスのインスタンスを入れる")]
    private GoblinInstanceLine m_goblinInstanceLine;

    private int m_goblinCount; //ゴブリンの数を数える
    private int m_mimicCount; //ミミックの数を数える
    private bool m_destroyFlg; //エフェクトを削除したかを判断するフラグ
    private ParticleSystem m_particleSystem;

    // Start is called before the first frame update
    private void Start()
    {
        m_goblinCount = 0;
        m_mimicCount = 0;
        m_destroyFlg = false;
        m_particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    private void Update()
    {
        //ゴブリンの数を取得し、記録する
        m_goblinCount = GameObject.FindGameObjectsWithTag("Goblin").Length;
        //ミミックの数を取得し、記録する
        m_mimicCount = GameObject.FindGameObjectsWithTag("ChestMonster").Length;
        //プレイヤーがライン(ミミック、ゴブリンをインスタンス化する基準となる線)を越えているかを判断するフラグを取得し、記録する
        bool playerInvasionFlg = m_goblinInstanceLine.PlayerInvasionFlgProperty;

        if (m_destroyFlg == false) //今までエフェクトが削除されていなかった場合
        {
            if (playerInvasionFlg == true && m_goblinCount <= 0 && m_mimicCount <= 0) //ゴブリン、ミミックのどちらもいない場合
            {
                m_destroyFlg = true; //エフェクトを削除出来る
                Color color = new Color32(255, 255, 255, 0);
                m_particleSystem.startColor = color;
                Destroy(this.gameObject, 3.5f); //3.5秒後にエフェクトを削除する
            }
        }
    }
}