using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player状态机.状态项目
    using UnityEngine;

public class PlayerMoveState : IState
{
    private readonly PlayerStateMachine player;
    private float moveSpeed = 5f;

    public PlayerMoveState(PlayerStateMachine player)
    {
        this.player = player;
    }

    public void OnEnter()
    {
        Debug.Log("进入移动状态");
    }

    public void OnUpdate()
    {
        Vector2 input = player.InputHandler.MoveInput;

        if (input == Vector2.zero)
        {
            player.ChangeState(new PlayerIdleState(player));
            return;
        }

        Vector3 move = new Vector3(input.x, 0, input.y);
        player.Controller.Move(move * moveSpeed * Time.deltaTime);
    }

    public void OnExit()
    {
        Debug.Log("退出移动状态");
    }
}