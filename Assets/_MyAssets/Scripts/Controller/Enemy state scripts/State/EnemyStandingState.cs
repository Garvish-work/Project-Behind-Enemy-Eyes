using UnityEngine;
using UnityEngine.AI;

public class EnemyStandingState : EnemyBaseState
{
    public EnemyStandingState(PatrolPointInfo _patrolPointInfo, NavMeshAgent _enemyNavAgent, EnemyAnimationController _animtionController) : base(_patrolPointInfo, _enemyNavAgent, _animtionController)
    {
        enemyState = EnemyState.STANDING;
    }

    float timeToChange = 0;
    public override void Enter()
    {
        base.Enter();
        timeToChange = 0;
    }
    public override void Update()
    {
        timeToChange += Time.deltaTime;

        if (timeToChange >= 5)
        {
            Exit();
            nextState = new EnemyPatrolState(patrolPointInfo, enemyNavAgent, animtionController);
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}
