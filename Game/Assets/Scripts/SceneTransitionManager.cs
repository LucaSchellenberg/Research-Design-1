using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    [Header("Survey Links")]
    public string firstSurveyURL;
    public string nextSceneName;
    [Header("UI Elements")]
    public GameObject menuPanel;

    void Update()
    {
        // Toggle menu on/off with ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuPanel.SetActive(!menuPanel.activeSelf);
        }
    }

    public void OpenFirstSurvey()
    {
        Application.OpenURL(firstSurveyURL);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
    public void CloseMenu()
    {
        menuPanel.SetActive(false);
    }
}
