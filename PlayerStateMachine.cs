using Player状态机.状态项目;
using UnityEngine;

[RequireComponent(typeof(PlayerInputHandler))]
public class PlayerStateMachine : MonoBehaviour
{
    private IState currentState;

    public PlayerInputHandler InputHandler { get; private set; }
    public CharacterController Controller { get; private set; }

    private void Awake()
    {
        InputHandler = GetComponent<PlayerInputHandler>();
        Controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        ChangeState(new PlayerIdleState(this));
    }

    private void Update()
    {
        currentState?.OnUpdate();
    }

    public void ChangeState(IState newState)
    {
        currentState?.OnExit();
        currentState = newState;
        currentState.OnEnter();
    }

}
