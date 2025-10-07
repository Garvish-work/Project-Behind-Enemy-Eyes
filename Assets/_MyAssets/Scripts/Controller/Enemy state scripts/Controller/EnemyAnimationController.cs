using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] public Animator animator;

    float lerptedLeanValue;
    float leanValue;

    float currentRotationValue;
    float lastRotationValue;
    float deltaRotationValue;

    public void ClaculateLeanValue()
    {
        currentRotationValue = transform.eulerAngles.y;
        deltaRotationValue = (((currentRotationValue - lastRotationValue) / 180) / Time.deltaTime);

        leanValue = deltaRotationValue;
        lastRotationValue = currentRotationValue;

        lerptedLeanValue = Mathf.MoveTowards(lerptedLeanValue, leanValue, 2f * Time.deltaTime);
        animator.SetFloat("LeanValue", lerptedLeanValue);
    }

    public void SetWalkingAnimation(bool check)
    {
        animator.SetBool("isPetroling", check);
    }
}
