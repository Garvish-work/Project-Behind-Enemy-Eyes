using UnityEngine;

[CreateAssetMenu (fileName = "Player data", menuName = "Scriptable/Player data")]
public class PlayerData : ScriptableObject
{
    public float playerCrouchSpeed = 0.8f;
    public float playerWalkSpeed = 1.0f;
    public float playerSprintSpeed = 3.0f;

    public float leanValue = 0;
    public Vector3 playerPosition = Vector3.zero;

    public bool playerCaught = false;
}
