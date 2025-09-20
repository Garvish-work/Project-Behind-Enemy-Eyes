using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private EnemyController enemyController;
    [SerializeField] public EnemyState enemyState;
    [SerializeField] public Animator animator;

    float lerptedLeanValue;
    float leanValue;

    float currentRotationValue;
    float lastRotationValue;
    float deltaRotationValue;

    private void Update()
    {
        switch (enemyController.GetEnemyState())
        {
            case EnemyState.PETROLING:
                animator.SetBool("isPetroling", true);
                break;
            case EnemyState.PAUSING:
                animator.SetBool("isPetroling", false);
                break;
        }
        ClaculateLeanValue();
    }

    private void ClaculateLeanValue()
    {
        currentRotationValue = transform.eulerAngles.y;
        deltaRotationValue = (((currentRotationValue - lastRotationValue) / 180) / Time.deltaTime);

        leanValue = deltaRotationValue;
        lastRotationValue = currentRotationValue;

        lerptedLeanValue = Mathf.MoveTowards(lerptedLeanValue, leanValue, 2f * Time.deltaTime);
        animator.SetFloat("LeanValue", lerptedLeanValue);
    }
}
