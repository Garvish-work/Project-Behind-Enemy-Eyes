using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameplayUiController : MonoBehaviour
{
    private void OnEnable()
    {
        ActionHandler.CaughtByEnemy += OnCaughtByEnemy;
    }

    private void OnDisable()
    {
        ActionHandler.CaughtByEnemy -= OnCaughtByEnemy;
    }

    private void OnCaughtByEnemy()
    {
        UI.ToolKit.ActionHandler.OpenCanvasAction?.Invoke(UI.ToolKit.CanvasNames.GAMEOVER_CANVAS);
        UI.ToolKit.ActionHandler.ClosePopup?.Invoke(UI.ToolKit.PopUpNames.CONTROL_POPUP);

        StartCoroutine(nameof(changeScene));
    }

    private IEnumerator changeScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
