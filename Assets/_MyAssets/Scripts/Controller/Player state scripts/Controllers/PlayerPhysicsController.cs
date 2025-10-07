using UnityEngine;

public class PlayerPhysicsController : MonoBehaviour
{
    Rigidbody playerRb;

    [Header("</b>Scriptables")]
    [SerializeField] private PlayerData playerData;
    [SerializeField] private InputData inputData;

    [Header("</b>Components")]
    [SerializeField] private Transform camTransform;

    [Header("</b>Values")]
    [SerializeField] private float rotationSmoothness = 10.0f;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    Vector3 movementVec = Vector3.zero;
    Vector3 appliedVelocity = Vector3.zero;
    float playerCurrentSpeed = 0;

    public void SetPlayerCurretSpeed(float setSpeed) => playerCurrentSpeed = setSpeed;
    public void PlayerMovement()
    {
        movementVec = (transform.forward * inputData.rawKeyboardY + transform.right * inputData.rawKeyboardX);
        appliedVelocity = movementVec.normalized * playerCurrentSpeed;

        appliedVelocity.y = playerRb.linearVelocity.y;
        playerRb.linearVelocity = appliedVelocity;
        ClaculateLeanValue();
    }

    float currentRotationValue;
    float lastRotationValue;
    float deltaRotationValue;
    private void ClaculateLeanValue()
    {
        currentRotationValue = camTransform.eulerAngles.y;
        deltaRotationValue = (((currentRotationValue - lastRotationValue) / 360) / Time.deltaTime);

        playerData.leanValue = deltaRotationValue;
        lastRotationValue = currentRotationValue;
    }

    public void RotatePlayer()
    {
        Quaternion quaternion = inputData.camRotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, quaternion, rotationSmoothness * Time.deltaTime);
    }

    public void SetCurrentSpeed(float desireSpeed)
    {
        playerCurrentSpeed = desireSpeed;
    }

    public void StopPhy()
    {
        playerRb.linearVelocity = Vector3.zero;
    }
}
