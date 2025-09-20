using TMPro;
using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashScreenUiController : MonoBehaviour
{
    [SerializeField] private TMP_Text uiText;

    private void Start()
    {
        StartCoroutine(nameof(ManageScene));
    }

    private IEnumerator ManageScene()
    {
        DisplayData();
        yield return new WaitForSeconds(3);
        UI.ToolKit.ActionHandler.CloseCavnvasAction?.Invoke(UI.ToolKit.CanvasNames.TASK_CANVAS);
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("MainScene-TerrainTest");
    }

    private void DisplayData()
    {
        DateTime currentDate = DateTime.Now;

        // Check if date is 6th November 1998
        if (currentDate.Day == 6 && currentDate.Month == 11 && currentDate.Year == 1998)
        {
            uiText.text = "HAPPY BIRTHDAY LOVE <3";
        }
        else
        {
            uiText.text = "Today is " + currentDate.ToString("dd MMMM yyyy") +"\nEnter correct date.";
        }
    }
}
