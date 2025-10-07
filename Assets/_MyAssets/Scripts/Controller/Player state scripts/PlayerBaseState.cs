using UnityEngine;

public class PlayerBaseState
{
    public enum PlayerState
    {
        IDLE, WALKING, CROUCHING, SPRINTING, CAUGHT
    };
    public enum StateEvents
    {
        ENTER, UPDATE, EXIT
    };
    // state components
    protected PlayerState playerState;
    protected StateEvents stateEvent;
    protected PlayerBaseState nextState;

    // scriptables
    protected InputData inputData;
    protected PlayerData playerData;

    // components
    protected Animator playerAnimator;

    // controllers
    protected PlayerPhysicsController phyController;
    protected PlayerAnimationController animController;

    public PlayerBaseState(InputData _inputData, PlayerData _playerData, Animator _playerAnimator, PlayerPhysicsController _phyController, PlayerAnimationController _animController)
    {
        inputData = _inputData;
        playerData = _playerData;

        playerAnimator = _playerAnimator;

        phyController = _phyController;
        animController= _animController;

        stateEvent = StateEvents.ENTER;
    }

    public virtual void Enter() { stateEvent = StateEvents.UPDATE; }
    public virtual void Update() { stateEvent = StateEvents.UPDATE; }
    public virtual void Exit() { stateEvent = StateEvents.EXIT; }

    public PlayerBaseState Process()
    {
        if (stateEvent == StateEvents.ENTER) Enter();
        if (stateEvent == StateEvents.UPDATE) Update();
        if (stateEvent == StateEvents.EXIT)
        {
            Exit();
            return nextState;
        }
        else return this;
    } 
}
