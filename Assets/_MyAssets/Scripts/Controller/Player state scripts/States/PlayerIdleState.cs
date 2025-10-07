using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState (InputData _inputData, PlayerData _playerData, Animator _playerAnimator, PlayerPhysicsController _phyController, PlayerAnimationController _animController) : base (_inputData, _playerData, _playerAnimator, _phyController, _animController) 
    {
        playerState = PlayerState.IDLE;
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        phyController.PlayerMovement();
    }
    public override void Exit()
    {
        base.Exit();

    }
}
