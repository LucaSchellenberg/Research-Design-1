using UnityEngine;

public class EndPrototypeManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject menuPanel;

    [Header("Survey Link")]
    public string finalSurveyURL;

    void Update()
    {
        // Toggle menu on/off with ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuPanel.SetActive(!menuPanel.activeSelf);
        }
    }

    public void OpenFinalSurvey()
    {
        Application.OpenURL(finalSurveyURL);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game quit (won't show in editor)");
    }

    public void CloseMenu()
    {
        menuPanel.SetActive(false);
    }
}
