using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMarker : MonoBehaviour
{
    ///<summary>
    ///魔法が発射されるPrefab
    ///</summary>
    [SerializeField, Tooltip("魔法が発射されるPrefab")]
    private GameObject _MagicShotPrefab;

    /// <summary>
    /// 放物線を構成する線分の数
    /// </summary>
    //[SerializeField]
    private int _segmentCount = 120;

    /// <summary>
    /// 放物線を何秒分計算するか(距離)
    /// </summary>
    private float _predictionTime =6.0f;

    ///<summary>
    ///放物線の開始座標
    ///</summary>
    private Vector3 _arcStartPosition;

    ///<summary>
    ///放物線の終了座標
    ///</summary>
    private Vector3 _arcEndPosition;

    public Vector3 GetMakerPosition
    {
        get { return _arcEndPosition; }
    }
    
    /// <summary>
    /// 着弾点のマーカーのオブジェクト
    /// </summary>
    private GameObject _pointerObject;

    private string _objectName;

    public void Draw(string objectName,GameObject makerPrefab,bool Flg = true)
    {
        //プレハブが違うのであれば別のプレハブに変える
        if (objectName != _objectName)
        {
            //今表示するプレハブを記憶する
            _objectName = objectName;

            //プレハブをインスタンス
            _pointerObject = Instantiate(makerPrefab,Vector3.zero,Quaternion.identity);
            _pointerObject.SetActive(false);
        }

        //マーカーの回転をプレイヤーと同じにする(常に正面を向く)
        _pointerObject.transform.rotation = transform.rotation;
        
        //放物線の開始座標を更新
        _arcStartPosition = _MagicShotPrefab.transform.position;

        //放射線を表示
        float timeStep = _predictionTime;
        bool draw = false;
        float hitTime = float.MaxValue;
        for (int i = 0; i < _segmentCount; i++)
        {
            //線の座標を更新
            float startTime = timeStep * i;
            float endTime = startTime + timeStep;

            //衝突判定
            if (!draw)
            {
                hitTime = GetArcHitTime(startTime,endTime);
                if (hitTime != float.MaxValue)
                {
                    //衝突したらその先の放射物は表示しない
                    draw = true;
                }
            }
        }

        //マーカーの表示    
        if (hitTime != float.MaxValue)
        {
            Vector3 hitPosition = GetArcPositionAtTime(hitTime);
            _arcEndPosition = hitPosition;
            ShowPointer(hitPosition,Flg);
        }

        //衝突判定
        // RaycastHit hit;
        // if (Physics.Raycast(_MagicShotPrefab.transform.position,transform.forward.normalized,out hit,60))
        // {
        //     Vector3 targetPos = _MagicShotPrefab.transform.position + (transform.forward.normalized * hit.distance);
        // }
    }

    /// <summary>
    /// 指定時間に対するアーチの放物線上の座標を返す
    /// </summary>
    /// <param name="time">経過時間</param>
    /// <returns>座標</returns>
    private Vector3 GetArcPositionAtTime(float time)
    {
        return (_arcStartPosition + ((_MagicShotPrefab.transform.forward * time)));
    }

    /// <summary>
    /// 指定座標にマーカーを表示
    /// </summary>
    private void ShowPointer(Vector3 position, bool Flg)
    {
        _pointerObject.transform.position = position;
        _pointerObject.gameObject.SetActive(Flg);
    }

    /// <summary>
    /// 2点間の線分で衝突判定し、衝突する時間を返す
    /// </summary>
    /// <returns>衝突した時間(してない場合はfloat.MaxValue)</returns>
    private float GetArcHitTime(float startTime, float endTime)
    {
        //Linecastする線分の始終点の座標
        Vector3 startPosition = GetArcPositionAtTime(startTime);
        Vector3 endPosition = GetArcPositionAtTime(endTime);

        //衝突判定
        RaycastHit hitInfo;
        if (Physics.Linecast(startPosition,endPosition,out hitInfo))
        {
            //衝突したColliderまで距離から実際の衝突時間を算出
            float distance = Vector3.Distance(startPosition,endPosition);
            return startTime + (endTime - startTime) * (hitInfo.distance / distance);
        }
        return float.MaxValue;
    }
}
