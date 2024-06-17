using UnityEngine;
using TMPro;

public class HealthPopupManager : MonoBehaviour
{
    public TextMeshProUGUI popupText;
    public float displayDuration = 2f; // Duration to display the popup

    private void Start()
    {
        gameObject.SetActive(false); // Ensure the popup is disabled at start
    }

    public void ShowPopup(string message)
    {
        popupText.text = message;
        gameObject.SetActive(true); // Enable the popup
        Invoke("HidePopup", displayDuration); // Schedule to hide the popup after the duration
    }

    private void HidePopup()
    {
        gameObject.SetActive(false); // Disable the popup
    }
}
