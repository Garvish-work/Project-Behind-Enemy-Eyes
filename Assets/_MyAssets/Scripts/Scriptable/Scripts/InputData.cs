using UnityEngine;

[CreateAssetMenu (fileName = "Input data", menuName = "Scriptable/Input data")]
public class InputData : ScriptableObject
{
    public InputType inputType;

    [Space]
    [Header("States")]
    public bool isMoving = false;
    public bool isSprinting = false;
    public bool isCrouching = false;

    [Header ("Keyboard inputs")]
    public float rawKeyboardX;
    public float rawKeyboardY;
    public float lerpValue = 5;
    public float lerpKeyboardX;
    public float lerpKeyboardY;

    [Header ("Mouse inputs")]
    public float mouseX;
    public float mouseY;
    public float mouseSensitivity;
    public float touchSensitivity;
    public Vector2 mouseVertThreshold;

    [Header ("Touch inputs")]
    public float rawTouchXValue;
    public float touchYawValue;
    public float touchPitchValue;

    [Header ("Camera inputs")]
    public Quaternion camRotation;
}
