using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject panel;

    private bool isPanelOpen = false;

    public void TogglePanel()
    {
        isPanelOpen = !isPanelOpen;
        panel.SetActive(isPanelOpen);
    }
}
