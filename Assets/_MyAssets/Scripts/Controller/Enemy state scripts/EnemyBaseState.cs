using UnityEngine;
using UnityEngine.AI;

public class EnemyBaseState 
{
    public enum EnemyState
    {
        STANDING, PATROL, CAUGHT_PLAYER
    };
    public enum StateEvents
    {
        ENTER, UPDATE, EXIT
    };
    protected EnemyState enemyState;
    protected StateEvents stateEvent;
    protected PatrolPointInfo patrolPointInfo;
    protected EnemyBaseState nextState;
    protected NavMeshAgent enemyNavAgent;
    protected EnemyAnimationController animtionController;

    public EnemyBaseState (PatrolPointInfo _patrolPointInfo, NavMeshAgent _enemyNavAgent, EnemyAnimationController _animtionController)
    {
        patrolPointInfo = _patrolPointInfo;
        enemyNavAgent = _enemyNavAgent;
        animtionController = _animtionController;

        stateEvent = StateEvents.ENTER;
    }

    public virtual void Enter() { stateEvent = StateEvents.UPDATE; }
    public virtual void Update() { stateEvent = StateEvents.UPDATE; }
    public virtual void Exit() { stateEvent = StateEvents.EXIT; }

    public EnemyBaseState Process()
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
