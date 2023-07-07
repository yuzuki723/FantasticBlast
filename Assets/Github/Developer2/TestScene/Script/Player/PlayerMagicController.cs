using UnityEngine;
using MagicState;
using UniRx;

public class PlayerMagicController : MonoBehaviour
{

    //魔法実装
    private Fire  _fire;
    private Ice   _ice;
    private Stone _stone;


    //変更前のステート
    private string _prevStateName;

    //ステート
    public StateProcessor  StateProcessor  {get; set;} = new StateProcessor();
    public MagicStateFire  MagicStateFire  {get; set;} = new MagicStateFire();
    public MagicStateIce   MagicStateIce   {get; set;} = new MagicStateIce();
    public MagicStateStone MagicStateStone {get; set;} = new MagicStateStone();

    void Start()
    {
        _fire  = GetComponent<Fire>();
        _ice   = GetComponent<Ice>();
        _stone = GetComponent<Stone>();

        //ステートの初期化
        StateProcessor.State.Value = MagicStateFire;
        MagicStateFire.ExecAction  = Fire;
        MagicStateIce.ExecAction   = Ice;
        MagicStateStone.ExecAction = Stone;
    }

    void Update()
    {
        //ステートを変更する
        ChangeState();

        //現在のステートで実行する
        ExecuteState();
    }

    private void ChangeState()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            StateProcessor.State.Value = MagicStateFire;
            Debug.Log("Now State:" + StateProcessor.State.Value.GetStateName());
        }

        if(Input.GetKeyDown(KeyCode.U))
        {
            StateProcessor.State.Value = MagicStateIce;
            Debug.Log("Now State:" + StateProcessor.State.Value.GetStateName());
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            StateProcessor.State.Value = MagicStateStone;
            Debug.Log("Now State:" + StateProcessor.State.Value.GetStateName());
        }
    }

    private void ExecuteState()
    {
        StateProcessor.State.Where(_ => StateProcessor.State.Value.GetStateName() != _prevStateName).Subscribe(_ =>
        {
            //実行
            StateProcessor.Execute();
        }).AddTo(this);
    }

    public void Fire()
    {
        _fire.ShotFireMagic();
    }

    public void Ice()
    {
        _ice.ShotIceMagic();
    }

    public void Stone()
    {
        _stone.ShotStoneMagic();
    }

    public string CurrentMagicState()
    {
        return StateProcessor.State.Value.GetStateName();
    }
}
