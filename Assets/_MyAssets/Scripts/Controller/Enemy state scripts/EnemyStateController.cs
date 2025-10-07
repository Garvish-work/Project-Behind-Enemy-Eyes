using UnityEngine;
using UnityEngine.AI;

public class EnemyStateController : MonoBehaviour
{
    EnemyBaseState currentState;

    [SerializeField] private PatrolPointInfo patrolPointInfo;
    [SerializeField] private NavMeshAgent enemyNavAgent;
    [SerializeField] private EnemyAnimationController animtionController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = new EnemyStandingState(patrolPointInfo, enemyNavAgent, animtionController);
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.Process();
    }
}

[System.Serializable]
public struct PatrolPointInfo
{
    public int pointIndex;
    public Transform[] patrolPoints;
}