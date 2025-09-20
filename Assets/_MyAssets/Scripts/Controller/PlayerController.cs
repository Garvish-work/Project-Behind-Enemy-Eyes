using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))] 
public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;

    [Header("</b>Scriptables")]
    [SerializeField] private PlayerData playerData;
    [SerializeField] private InputData inputData;

    [Header("</b>Components")]
    [SerializeField] private Transform camTransform;

    [Header("</b>Values")]
    [SerializeField] private float rotationSmoothness = 10.0f;

    Vector3 movementVec = Vector3.zero;
    float playerCurrentSpeed = 0;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void Update()
    {
        ClaculateLeanValue();
        SprintControls();
        if (inputData.rawKeyboardX != 0 || inputData.rawKeyboardY != 0)
            RotatePlayer();
        playerData.playerPosition = transform.position;
    }

    Vector3 appliedVelocity = Vector3.zero;
    private void PlayerMovement()
    {
        movementVec = (transform.forward * inputData.rawKeyboardY + transform.right * inputData.rawKeyboardX);
        appliedVelocity = movementVec.normalized * playerCurrentSpeed;

        appliedVelocity.y = playerRb.linearVelocity.y;
        playerRb.linearVelocity = appliedVelocity;
    }

    private void RotatePlayer()
    {
        Quaternion quaternion = inputData.camRotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, quaternion, rotationSmoothness * Time.deltaTime);
    }

    private void SprintControls()
    {
        if (inputData.isSprinting) playerCurrentSpeed = playerData.playerSprintSpeed;
        else if (inputData.isCrouching) playerCurrentSpeed = playerData.playerCrouchSpeed;
        else playerCurrentSpeed = playerData.playerWalkSpeed;
    }

    float currentRotationValue;
    float lastRotationValue;
    float deltaRotationValue;

    private void ClaculateLeanValue()
    {
        currentRotationValue = camTransform.eulerAngles.y;
        deltaRotationValue = (((currentRotationValue - lastRotationValue)/360) / Time.deltaTime);
        
        playerData.leanValue = deltaRotationValue;
        lastRotationValue = currentRotationValue;
    }
}
