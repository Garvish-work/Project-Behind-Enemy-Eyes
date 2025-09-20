using UnityEngine;
using UnityEngine.EventSystems;

public class UiDragHandler : MonoBehaviour, IDragHandler
{
    [SerializeField] private InputData inputData;
    [SerializeField] private PlayerData playerData;

    public void OnDrag(PointerEventData eventData)
    {
        if (playerData.playerCaught)
        {
            return;
        }

        inputData.touchYawValue -= eventData.delta.y * inputData.touchSensitivity; 
        inputData.touchPitchValue += eventData.delta.x * inputData.touchSensitivity;

        inputData.touchYawValue = Mathf.Clamp(inputData.touchYawValue, inputData.mouseVertThreshold.x, inputData.mouseVertThreshold.y);
    }
}
