using UnityEngine;

public class PlayerCaughtState : PlayerBaseState
{
    public PlayerCaughtState(InputData _inputData, PlayerData _playerData, Animator _playerAnimator, PlayerPhysicsController _phyController, PlayerAnimationController _animController) : base(_inputData, _playerData, _playerAnimator, _phyController, _animController)
    {
        playerState = PlayerState.CROUCHING;
    }
    public override void Enter()
    {
        base.Enter();
        animController.StopAnim();
        phyController.StopPhy();
    }
    public override void Update()
    {

    }
    public override void Exit()
    {
        base.Exit();
    }
}
