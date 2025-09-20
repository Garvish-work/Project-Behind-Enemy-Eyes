using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerDetectionController))]
public class PlayerDetectionUiController : MonoBehaviour, IUpdateUi
{
    [Header("<b>Components")]
    [SerializeField] private Animator animator;

    [Header("<b>Scriptable")]
    [SerializeField] private PlayerData playerData;
     
    [Header("<b>User interface")]
    [SerializeField] private Image eyeImage;
    [SerializeField] private CanvasGroup mainCanvas;

    public void EnableGUI()
    {
        animator.SetTrigger("Enable");
    }

    public void DisableGUI()
    {
        animator.SetTrigger("Disable");
    }

    public void UpdateGUI(float updateValue)
    {
        mainCanvas.transform.LookAt(playerData.playerPosition, Vector3.up);
        eyeImage.fillAmount = updateValue;
    }
}
