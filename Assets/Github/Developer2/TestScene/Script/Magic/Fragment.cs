using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// オブジェクトを周囲に飛び散らせる処理をまとめた
/// </summary>
public class Fragment : MonoBehaviour
{
    /// <summary>
    /// 破片のステータス
    /// </summary>
    private FragmentStatus _fragmentStatus = new FragmentStatus();

    public class FragmentStatus
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

    /// <summary>
    /// 破片のステータスをセットする
    /// </summary>
    /// <param name="prafab">破片のプレハブ</param>
    /// <param name="number">出現する数</param>
    /// <param name="speed">出現する速さ</param>
    /// <param name="destroyTiem">出現からどのくらいで消滅するか</param>
    public void SetFragmentStatus(GameObject prafab, float number, float speed, float destroyTiem)
    {
        _fragmentStatus.Prefab = prafab;
        _fragmentStatus.Number = number;
        _fragmentStatus.Speed = speed;
        _fragmentStatus.DestroyTime = destroyTiem;
    }

    /// <summary>
    /// 周囲に破片をまき散らす
    /// </summary>
    public void FlyAroundFragment()
    {
        // _fragmentNumberの数ぶん出現する
        for (int i = 0; i < _fragmentStatus.Number; i++)
        {
            // 破片をインスタンス(角度はランダムに設定)
            GameObject fagment = Instantiate(_fragmentStatus.Prefab, transform.position, Random.rotation);

            // ランダムな方向ベクトルを取得
            Vector3 randVec = Random.insideUnitSphere.normalized;

            // ランダムな方向に破片を飛ばす
            Rigidbody rigidbody = fagment.GetComponent<Rigidbody>();
            rigidbody.AddForce(randVec * _fragmentStatus.Speed, ForceMode.Impulse);

            // 時間になったら消す
            Destroy(fagment, _fragmentStatus.DestroyTime);
        }
    }
}



