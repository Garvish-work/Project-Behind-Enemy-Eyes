using UnityEngine;

public class PlayerCrouchState : PlayerBaseState
{
    public PlayerCrouchState(InputData _inputData, PlayerData _playerData, Animator _playerAnimator, PlayerPhysicsController _phyController, PlayerAnimationController _animController) : base(_inputData, _playerData, _playerAnimator, _phyController, _animController)
    {
        playerState = PlayerState.CROUCHING;
    }
    public override void Enter()
    {
        base.Enter();
        phyController.SetCurrentSpeed(playerData.playerCrouchSpeed);
        animController.GoIntoCrouchState(true);
    }
    public override void Update()
    {
        animController.Animate();
        phyController.PlayerMovement();
        if (inputData.rawKeyboardX != 0 || inputData.rawKeyboardY != 0) phyController.RotatePlayer();

        if (inputData.isSprinting)
        {
            Exit();
            nextState = new PlayerSprintState(inputData, playerData, playerAnimator, phyController, animController);
        }
        if (!inputData.isCrouching)
        {
            Exit();
            nextState = new PlayerWalkingState(inputData, playerData, playerAnimator, phyController, animController);
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
        animController.GoIntoCrouchState(false);
    }
}
