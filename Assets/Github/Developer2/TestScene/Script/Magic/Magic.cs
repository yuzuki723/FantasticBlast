using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    /// <summary>
    /// 魔法それぞれのダメージ量をいれる
    /// </summary>
    [SerializeField] public float _magicDamage;

    /// <summary>
    /// 魔法のダメージ量を参照する
    /// </summary>
    public float GetMagicDamage
    {
        get { return _magicDamage; }
    }
}
