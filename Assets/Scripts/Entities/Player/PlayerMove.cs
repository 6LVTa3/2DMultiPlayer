using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : NetworkBehaviour
{
    [SerializeField] private InputAction moveInput;
    [SerializeField] private float speed;
    [SerializeField] private PlayerAnimation playerAnimation;
    [SerializeField] private NetworkIdentity netID;
    private Vector2 moveDirection;

    private void Start()
    {
        
        if (netID.isOwned)
        {
            moveInput.Enable();
        }
        
        
    }

    private void Update()
    {
       // Debug.Log(moveInput.ReadValue<Vector2>().ToString());
        if (moveInput.ReadValue<Vector2>() == Vector2.zero)
        {
            switch (moveDirection.x,moveDirection.y)
            {
                case (0,< 0):
                    {
                        playerAnimation.ChangeState(AnimStates.IdleDown);
                        break;
                    }
                case (0,>0):
                    {
                        playerAnimation.ChangeState(AnimStates.IdleUp);
                        break;
                    }
                case (-1, 0):
                    {
                        playerAnimation.ChangeState(AnimStates.IdleSide);
                        transform.localScale = new Vector3(-1, 1, 1);
                        break;
                    }
                case (1, 0):
                    {
                        playerAnimation.ChangeState(AnimStates.IdleSide);
                        transform.localScale = new Vector3(1, 1, 1);
                        break;
                    }
            }

            
        }
        else
        {
            moveDirection = moveInput.ReadValue<Vector2>();
            transform.position += (Vector3)moveDirection * speed * Time.deltaTime;
            switch (moveDirection.x, moveDirection.y)
            {
                case (0, < 0):
                    {
                        playerAnimation.ChangeState(AnimStates.WalkDown);
                        break;
                    }
                case (0, > 0):
                    {
                        playerAnimation.ChangeState(AnimStates.WalkUp);
                        break;
                    }
                case (-1, 0):
                    {
                        playerAnimation.ChangeState(AnimStates.WalkSide);
                        transform.localScale = new Vector3(-1, 1, 1);
                        break;
                    }
                case (1, 0):
                    {
                        playerAnimation.ChangeState(AnimStates.WalkSide);
                        transform.localScale = new Vector3(1, 1, 1);
                        break;
                    }
            }
        }


    }
}
