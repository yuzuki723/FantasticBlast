using UnityEngine;
using System;
using UniRx;

namespace MagicState
{
    ///<summary>
    ///Stateの実行を管理するクラス
    ///</summary>
    public class StateProcessor
    {
        //ステート本体
        public ReactiveProperty<MagicState> State { get; set;} = new ReactiveProperty<MagicState>();
    
        //通常魔法実行
        public void Execute() => State.Value.Execute();

        //特殊魔法実行
        
    }

    ///<summary>
    ///ステートのクラス
    ///</summary>
    public abstract class MagicState
    {
        //デリゲート
        public Action ExecAction {get; set;}

        //実行処理
        public virtual void Execute()
        {
            if(ExecAction != null)
            {
                ExecAction();
            }
        }

        //ステート名を取得するメゾット
        public abstract string GetStateName();
    }

    //=========================================================================
    //各魔法ステートクラス
    //=========================================================================

    ///<summary>
    ///炎魔法
    ///</summary>
    public class MagicStateFire : MagicState
    {
        public override string GetStateName()
        {
            return "Fire";
        }
    }

    ///<summary>
    ///氷魔法
    ///</summary>
    public class MagicStateIce : MagicState
    {
        public override string GetStateName()
        {
            return "Ice";
        }
    }

    ///<summary>
    ///土魔法
    ///</summary>
    public class MagicStateStone : MagicState
    {
        public override string GetStateName()
        {
            return "Stone";
        }
    }
}
