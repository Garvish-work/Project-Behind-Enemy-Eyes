using TMPro;
using UnityEngine;

public class CrouchButtonHandler : MonoBehaviour
{
    [SerializeField] private InputData inputData;
    [SerializeField] private TMP_Text crouchText;

    private void Awake()
    {
        B_UpdateButtonUi();
    }

    public void B_UpdateButtonUi()
    {
        if (inputData.isCrouching) crouchText.text = "GET-UP";
        else crouchText.text = "CROUCH";
    }
}
