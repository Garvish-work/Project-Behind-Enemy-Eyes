using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using Unity.VisualScripting;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyState enemyState;
    [SerializeField] private NavMeshAgent enemyAgent;
    [SerializeField] private PetrolPointIdentity petrolPoint;

    [SerializeField] private bool stopOnPoints = false;

    Transform petrolPointTransform;
    private void Start()
    {
        UpdatePetrolPoint(petrolPoint);
    }

    public EnemyState GetEnemyState()
    {
        return enemyState;
    }

    private void Update()
    {
        switch (enemyState)
        {
            case EnemyState.PETROLING:
                float distance = Vector3.Distance(enemyAgent.transform.position, petrolPointTransform.position);
                if (distance < 1)
                {
                    if (stopOnPoints)
                    {
                        StartCoroutine(nameof(StopAndUpdatePoints), petrolPoint.GetNextPetrolPoint());
                    }
                    else UpdatePetrolPoint(petrolPoint.GetNextPetrolPoint());
                }
            break;
        }
    }

    private void UpdatePetrolPoint(PetrolPointIdentity nextPetrolPoint)
    {
        
        petrolPoint = nextPetrolPoint;
        petrolPointTransform = petrolPoint.GetNextPetrolPoint().transform;
        enemyAgent.SetDestination(petrolPointTransform.position);
    }

    private IEnumerator StopAndUpdatePoints(PetrolPointIdentity nextPetrolPoint)
    {
        enemyAgent.speed = 0;
        enemyState = EnemyState.PAUSING;
        yield return new WaitForSeconds(5);

        enemyState = EnemyState.PETROLING;
        enemyAgent.speed = 1.5f;
        petrolPoint = nextPetrolPoint;

        petrolPointTransform = petrolPoint.GetNextPetrolPoint().transform;
        enemyAgent.SetDestination(petrolPointTransform.position);
    }
}