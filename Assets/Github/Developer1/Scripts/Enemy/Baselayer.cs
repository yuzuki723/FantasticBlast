using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class Baselayer : StateMachineBehaviour
{
    [SerializeField]
    [Tooltip("GetNavMeshAgentクラスのインスタンスを入れる")]
    private GetNavMeshAgent m_getNavMeshAgent;

    [SerializeField]
    [Tooltip("ChestMonsterAnimationFlgSetクラスのインスタンスを入れる")]
    private ChestMonsterAnimationFlgSet m_chestMonsterAnimationFlgSet;

    [SerializeField]
    [Tooltip("ChestMonsterColliderクラスのインスタンスを入れる")]
    private ChestMonsterCollider m_chestMonsterCollider;

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("Attack01")) //アニメーションのAttack01ステートを探す
        {
            m_chestMonsterCollider.AttackColliderOnFlgProperty = true; //当たり判定をONする
        }
        else
        {
            if (stateInfo.IsName("IdleNormal")) //アニメーションのIdleNormalステートを探す
            {
                m_chestMonsterAnimationFlgSet.DoNotMoveFlgProperty = true;
            }
        }
    }

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("Taunting")) //アニメーションのTauntingステートを探す
        {
            m_getNavMeshAgent.TauntingEndFlgProperty = true; //Tauntingアニメーションが終了した
        }
        else
        {
            if (stateInfo.IsName("Attack01")) //アニメーションのAttack01ステートを探す
            {
                m_chestMonsterCollider.AttackColliderOnFlgProperty = false; //当たり判定をfalseする
            }
            else
            {
                if(stateInfo.IsName("IdleNormal")) //アニメーションのIdleNormalステートを探す
                {
                    m_chestMonsterAnimationFlgSet.DoNotMoveFlgProperty = false; //一旦攻撃アニメーションから離れる
                }
            }
        }
    }

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMachineEnter is called when entering a state machine via its Entry Node
    //override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    //{
    //    
    //}

    // OnStateMachineExit is called when exiting a state machine via its Exit Node
    //override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    //{
    //    
    //}
}