using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class Baselayer : StateMachineBehaviour
{
    [SerializeField]
    [Tooltip("GetNavMeshAgent�N���X�̃C���X�^���X������")]
    private GetNavMeshAgent m_getNavMeshAgent;

    [SerializeField]
    [Tooltip("ChestMonsterAnimationFlgSet�N���X�̃C���X�^���X������")]
    private ChestMonsterAnimationFlgSet m_chestMonsterAnimationFlgSet;

    [SerializeField]
    [Tooltip("ChestMonsterCollider�N���X�̃C���X�^���X������")]
    private ChestMonsterCollider m_chestMonsterCollider;

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("Attack01")) //�A�j���[�V������Attack01�X�e�[�g��T��
        {
            m_chestMonsterCollider.AttackColliderOnFlgProperty = true; //�����蔻���ON����
        }
        else
        {
            if (stateInfo.IsName("IdleNormal")) //�A�j���[�V������IdleNormal�X�e�[�g��T��
            {
                m_chestMonsterAnimationFlgSet.DoNotMoveFlgProperty = true;
            }
        }
    }

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("Taunting")) //�A�j���[�V������Taunting�X�e�[�g��T��
        {
            m_getNavMeshAgent.TauntingEndFlgProperty = true; //Taunting�A�j���[�V�������I������
        }
        else
        {
            if (stateInfo.IsName("Attack01")) //�A�j���[�V������Attack01�X�e�[�g��T��
            {
                m_chestMonsterCollider.AttackColliderOnFlgProperty = false; //�����蔻���false����
            }
            else
            {
                if(stateInfo.IsName("IdleNormal")) //�A�j���[�V������IdleNormal�X�e�[�g��T��
                {
                    m_chestMonsterAnimationFlgSet.DoNotMoveFlgProperty = false; //��U�U���A�j���[�V�������痣���
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