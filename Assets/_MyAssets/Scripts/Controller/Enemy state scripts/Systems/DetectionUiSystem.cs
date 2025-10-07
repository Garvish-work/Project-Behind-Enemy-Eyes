using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(EnemyDetectionSystem))]
public class DetectionUiSystem : MonoBehaviour, IUpdateUi
{
    [Header("<b>Components")]
    [SerializeField] private Animator animator;

    [Header("<b>Scriptable")]
    [SerializeField] private Transform player;
     
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
        mainCanvas.transform.LookAt(player.position, Vector3.up);
        eyeImage.fillAmount = updateValue;
    }
}
