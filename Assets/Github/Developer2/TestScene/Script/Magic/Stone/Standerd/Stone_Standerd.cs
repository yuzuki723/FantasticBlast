using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_Standerd : MonoBehaviour
{

    ///<summary>
    ///破壊時の破片プレハブ
    ///</summary>
    [SerializeField] GameObject _fragmentPrefab;

    ///<summary>
    ///飛び散る破片の数
    ///</summary>
    [SerializeField] private float _fragmentNumber = 10;

    ///<summary>
    ///飛び散る破片の速さ
    ///</summary>
    [SerializeField] private float _fragmentSpeed = 1;

    ///<summary>
    ///飛び散る破片が消える時間
    ///</summary>
    [SerializeField] private float _fragmentDestroyTime = 1;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        FlyAroundFragment();
    }

    ///<summary>
    ///周囲に破片をまき散らす
    ///</summary>
    private void FlyAroundFragment()
    {
        //_fragmentNumberの数分出現する
        for (int i = 0; i < _fragmentNumber; i++)
        {
            //破片をインスタンス(角度はランダムに設定)
            GameObject fagment = Instantiate(_fragmentPrefab,transform.position,Random.rotation);

            //ランダムな方向ベクトルを取得
            Vector3 randVec = Random.insideUnitSphere.normalized;

            //ランダムな方向に破片を飛ばす
            Rigidbody rigidbody = fagment.GetComponent<Rigidbody>();
            rigidbody.AddForce(randVec * _fragmentSpeed,ForceMode.Impulse);

            //時間になったら消す
            Destroy(fagment,_fragmentDestroyTime);
        }
    }
}
