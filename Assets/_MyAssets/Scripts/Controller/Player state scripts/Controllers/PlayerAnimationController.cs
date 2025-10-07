using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private InputData inputData;
    [SerializeField] private Animator animator;

    float _mouseInput;
    float leanValue;
    [SerializeField] private float leanValueSmoothness = 20f;

    public void Animate()
    {
        animator.SetFloat("xValue", inputData.lerpKeyboardX);
        animator.SetFloat("yValue", inputData.lerpKeyboardY);

        if (inputData.isMoving)
        {
            switch (inputData.inputType)
            {
                case InputType.KEYBOARD:
                    _mouseInput = playerData.leanValue;
                    break;
                case InputType.TOUCH:
                    _mouseInput = playerData.leanValue;
                    break;
            }
        }
        else _mouseInput = 0;

        leanValue = Mathf.MoveTowards(leanValue, _mouseInput, leanValueSmoothness * Time.deltaTime);
        animator.SetFloat("LeanValue", leanValue);
    }

    public void GoIntoCrouchState(bool check)
    {
        animator.SetBool("isCrouching", check);
    }

    public void GoIntoSprintState(bool check)
    {
        animator.SetBool("isSprinting", check);
    }

    public void StopAnim()
    {
        animator.SetFloat("xValue", 0);
        animator.SetFloat("yValue", 0);

        animator.SetBool("isSprinting", false);
        animator.SetBool("isCrouching", false);
    }
}
