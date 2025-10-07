using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolState : EnemyBaseState
{
    public EnemyPatrolState(PatrolPointInfo _patrolPointInfo, NavMeshAgent _enemyNavAgent, EnemyAnimationController _animtionController) : base(_patrolPointInfo, _enemyNavAgent, _animtionController)
    {
        enemyState = EnemyState.PATROL;
    }

    Vector3 destinationPos = Vector3.zero;
    public override void Enter()
    {
        base.Enter();
        if (patrolPointInfo.pointIndex < patrolPointInfo.patrolPoints.Length - 1)
            patrolPointInfo.pointIndex += 1;
        else patrolPointInfo.pointIndex = 0;

        destinationPos = patrolPointInfo.patrolPoints[patrolPointInfo.pointIndex].position;
        enemyNavAgent.SetDestination(destinationPos);

        enemyNavAgent.speed = 1.5f;
        animtionController.SetWalkingAnimation(true);
    }
    public override void Update()
    {
        animtionController.ClaculateLeanValue();

        float distance = Vector3.Distance(destinationPos, enemyNavAgent.transform.position);
        if (distance < 1)
        {
            Exit();
            nextState = new EnemyStandingState(patrolPointInfo, enemyNavAgent, animtionController);
        }
    }
    public override void Exit()
    {
        base.Exit();
        enemyNavAgent.speed = 0f;
        animtionController.SetWalkingAnimation(false);
    }
}
