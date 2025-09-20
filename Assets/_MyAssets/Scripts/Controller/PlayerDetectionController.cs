using UnityEngine;
using System.Collections;

public class PlayerDetectionController : MonoBehaviour
{
    IUpdateUi uiUpdater;
    [Header("<b>Scriptable")]
    [SerializeField] private PlayerData playerData;

    [Header("<b>Components")]
    [SerializeField] private LayerMask wallLayerMask;
    [SerializeField] private Transform originPoint;
    [SerializeField] private Transform targetPoint;

    [Header("<b>Values")]
    [SerializeField] private float doubtValue;
    [SerializeField] private float doubtMultiplier = 0.5f; 
    [SerializeField] private float distanceCofficient = 30f; 

    float dotProduct;
    float distance; 
    public bool playerVisible = false;

    private void Awake() => uiUpdater = GetComponent<IUpdateUi>();

    private void Start()
    {
        playerData.playerCaught = false;
    }

    private void Update()
    {
        PlayerDetection();
    }

    private void PlayerDetection()
    {
        Vector3 direction = targetPoint.position - originPoint.position;
        distance = direction.magnitude;
        direction /= distance;

        dotProduct = Vector3.Dot(direction.normalized, originPoint.forward.normalized);
        if (dotProduct < 0.3f) // out of FOV
        {
            Debug.DrawRay(originPoint.position, direction * distance, Color.yellow);
            playerVisible = false;
            return;
        }

        // inside fov but something is blocking
        if (Physics.Raycast(originPoint.position, direction, out RaycastHit hit, distance, wallLayerMask))
        {
            Debug.Log("Something is in between: " + hit.collider.name);
            Debug.DrawLine(originPoint.position, targetPoint.position, Color.red);
            playerVisible = false;
        }
        else // enemy can see player
        {
            Debug.Log("Clear line of sight!");
            Debug.DrawRay(originPoint.position, direction * distance, Color.green);

            if (!doubleControllerStarted && !playerVisible)
            {
                StartCoroutine(nameof(DoubtValueController));
            }
            playerVisible = true;
        }
    }

    bool doubleControllerStarted = false;
    private IEnumerator DoubtValueController()
    {
        Debug.Log("Corouting started");
        doubleControllerStarted = true;
        uiUpdater.EnableGUI();
        doubtValue = 0.05f;

        while (playerVisible || doubtValue > 0)
        {
            if(doubtValue == 1)
            {
                if (!playerData.playerCaught) 
                {
                    ActionHandler.CaughtByEnemy?.Invoke();
                    playerData.playerCaught = true;
                }
            }
            if (playerVisible) doubtValue += (doubtMultiplier / (distance/ distanceCofficient)) * Time.deltaTime;
            else doubtValue -= (doubtMultiplier/2) * Time.deltaTime;

            doubtValue = Mathf.Clamp(doubtValue, 0, 1);
            uiUpdater.UpdateGUI(doubtValue);
            yield return null;
        }

        uiUpdater.DisableGUI();
        doubleControllerStarted = false;
        Debug.Log("Corouting ended");
    }
}
