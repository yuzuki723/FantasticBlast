using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_Standerd : MonoBehaviour
{

    /// <summary>
    /// 破片クラス呼び出し用
    /// </summary>
    private Fragment _fragment;

    [SerializeField, Tooltip("破片のステータス")]
    SetFragmentStatus _fragmentStatus = new SetFragmentStatus();
    [System.Serializable]
    public class SetFragmentStatus
    {
        /// <summary>
        /// 破壊時の破片プレハブ
        /// </summary>
        public GameObject Prefab;

        /// <summary>
        /// 飛び散る破片の数
        /// </summary>
        public float Number;

        /// <summary>
        /// 飛び散る破片の速さ
        /// </summary>
        public float Speed;

        /// <summary>
        /// 飛び散る破片が消える時間
        /// </summary>
        public float DestroyTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        //破片のステータスを加える
        _fragment = GetComponent<Fragment>();
        _fragment.SetFragmentStatus(_fragmentStatus.Prefab, _fragmentStatus.Number, _fragmentStatus.Speed, _fragmentStatus.DestroyTime);

        //魔法の消滅を分かりやすくするため消滅した座標から破片が飛び散る
        _fragment.FlyAroundFragment();
    }
}
