using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Standard : MonoBehaviour
{
    //回転
    [SerializeField] float _rotateX;
    [SerializeField] float _rotateY;
    [SerializeField] float _rotateZ;

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

    private void Start()
    {
        //何も衝突せず、3秒が経過したらその場で消滅する
        Destroy(gameObject,3);
    }

    void Update()
    {
        //常に回転し続ける
        Rotate();
    }

    ///<summary>
    ///回転
    ///</summary>
    private void Rotate()
    {
        gameObject.transform.Rotate(new Vector3(_rotateX,_rotateY,_rotateZ)* Time.deltaTime);
    }

    ///<summary>
    ///何かのオブジェクトに衝突したら呼び出し
    ///</summary>
    ///<param name="other">衝突した相手</param>
    private void OnCollisionEnter(Collision other)
    {
        //魔法を消去する
        Destroy(gameObject);
    }

    ///<summary>
    ///オブジェクトが消滅したら呼び出し
    ///</summary>
    private void OnDestroy()
    {
        //魔法の消滅を分かりやすくするため消滅した座標から破片が飛び散る
        FlyAroundFragment();
    }

    ///<summary>
    ///周囲に破片をまき散らす
    ///</summary>
    private void FlyAroundFragment()
    {
        //_fragmentNumberの数ぶん出現する
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
