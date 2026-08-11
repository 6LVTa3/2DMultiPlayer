using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private AnimStates curState;
    public void ChangeState(AnimStates state)
    {
        if (curState != state)
        {
            curState = state;
            Debug.Log(state.ToString());
            foreach (AnimatorControllerParameter parameter in animator.parameters)
            {
                animator.ResetTrigger(parameter.name);
            }
            animator.SetTrigger(state.ToString());
        }
        
        
    }

}

public enum AnimStates
{
    IdleUp = 0,
    IdleSide = 1,
    IdleDown = 2,
    WalkDown = 3,
    WalkSide = 4,
    WalkUp = 5
}