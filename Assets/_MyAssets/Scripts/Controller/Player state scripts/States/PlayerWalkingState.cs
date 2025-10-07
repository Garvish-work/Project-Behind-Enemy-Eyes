using UnityEngine;

public class PlayerWalkingState : PlayerBaseState
{
    public PlayerWalkingState(InputData _inputData, PlayerData _playerData, Animator _playerAnimator, PlayerPhysicsController _phyController, PlayerAnimationController _animController) : base(_inputData, _playerData, _playerAnimator, _phyController, _animController)
    {
        playerState = PlayerState.WALKING;
    }
    public override void Enter()
    {
        base.Enter();
        phyController.SetCurrentSpeed(playerData.playerWalkSpeed);
        animController.GoIntoSprintState(false);
    }
    public override void Update()
    {
        animController.Animate();
        phyController.PlayerMovement();
        if (inputData.rawKeyboardX !=0 || inputData.rawKeyboardY != 0) phyController.RotatePlayer();

        if (inputData.isSprinting)
        {
            Exit();
            nextState = new PlayerSprintState(inputData, playerData, playerAnimator, phyController, animController);
        }
        if (inputData.isCrouching)
        {
            Exit();
            nextState = new PlayerCrouchState(inputData, playerData, playerAnimator, phyController, animController);
        }
        if (playerData.playerCaught)
        {
            Exit();
            nextState = new PlayerCaughtState(inputData, playerData, playerAnimator, phyController, animController);
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}
