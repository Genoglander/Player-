using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player状态机.状态项目
{
    using System.Diagnostics;
    using System.Numerics;
    using UnityEngine;

    public class PlayerIdleState : IState
    {
        private readonly PlayerStateMachine player;

        public PlayerIdleState(PlayerStateMachine player)
        {
            this.player = player;
        }

        public void OnEnter()
        {
            Debug.Log("进入Idle状态");
        }

        public void OnUpdate()
        {
            Vector2 input = player.InputHandler.MoveInput;
            if (input != Vector2.zero)
            {
                player.ChangeState(new PlayerMoveState(player));
            }
        }

        public void OnExit()
        {
            Debug.Log("离开Idle状态");
        }
    }
}
