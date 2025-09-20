using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private InputData inputData;
    [SerializeField] private Animator animator;

    float _mouseInput;
    float leanValue;
    [SerializeField] private float leanValueSmoothness = 20f;

    private void Update()
    {
        Animate();
    }

    private void Animate()
    {
        animator.SetFloat("xValue", inputData.lerpKeyboardX);
        animator.SetFloat("yValue", inputData.lerpKeyboardY);

        animator.SetBool("isSprinting", inputData.isSprinting);
        animator.SetBool("isCrouching", inputData.isCrouching);

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
}
