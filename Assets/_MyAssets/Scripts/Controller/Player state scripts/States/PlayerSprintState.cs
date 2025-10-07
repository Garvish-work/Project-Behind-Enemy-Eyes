using UnityEngine;

public class PlayerSprintState : PlayerBaseState
{
    public PlayerSprintState(InputData _inputData, PlayerData _playerData, Animator _playerAnimator, PlayerPhysicsController _phyController, PlayerAnimationController _animController) : base(_inputData, _playerData, _playerAnimator, _phyController, _animController)
    {
        playerState = PlayerState.SPRINTING;
    }
    public override void Enter()
    {
        base.Enter();
        animController.GoIntoSprintState(true);
        phyController.SetCurrentSpeed(playerData.playerSprintSpeed);
    }
    public override void Update()
    {
        animController.Animate();
        phyController.PlayerMovement();
        phyController.RotatePlayer();

        if (!inputData.isSprinting)
        {
            Exit();
            nextState = new PlayerWalkingState(inputData, playerData, playerAnimator, phyController, animController);
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
        animController.GoIntoSprintState(false);
    }
}
