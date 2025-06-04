using UnityEngine;

public class InfoScreen : MonoBehaviour
{
    public GameObject infoPanel;

    public void ShowInfo()
    {
        infoPanel.SetActive(true);
    }

    public void HideInfo()
    {
        infoPanel.SetActive(false);
    }
}
