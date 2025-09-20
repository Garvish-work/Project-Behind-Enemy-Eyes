using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("<b>Scriptable")]
    [SerializeField] private InputData inputData;
    [SerializeField] private CameraData cameraData;

    [Header ("<b>Components")]
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform yawTransform;
    [SerializeField] private Transform pitchTransform;

    float yaw;
    float pitch;
    Vector3 rotationVector;
    Vector3 headVector;

    private void Update()
    {
        ControllerFunction();
        FollowPlayer();
        inputData.camRotation = yawTransform.rotation;
    }

    private void ControllerFunction()
    {
        switch (inputData.inputType)
        {
            case InputType.KEYBOARD:
                yaw += inputData.mouseX * inputData.mouseSensitivity * Time.deltaTime;
                pitch -= inputData.mouseY * inputData.mouseSensitivity * Time.deltaTime;
                pitch = Mathf.Clamp(pitch, inputData.mouseVertThreshold.x, inputData.mouseVertThreshold.y);

                headVector.x = pitch; rotationVector.y = yaw;
                yawTransform.rotation = Quaternion.Euler(rotationVector);
                pitchTransform.localRotation = Quaternion.Euler(headVector);
                break;

            case InputType.TOUCH:
                headVector.x = inputData.touchYawValue; 
                rotationVector.y = inputData.touchPitchValue;

                yawTransform.rotation = Quaternion.Euler(rotationVector);
                pitchTransform.localRotation = Quaternion.Euler(headVector);
                break;
        }
    }

    private void FollowPlayer()
    {
        cameraTransform.position = Vector3.MoveTowards(cameraTransform.position, playerTransform.position, cameraData.camFollowSpeed * Time.deltaTime);
    }
}
