using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    public Button bashButton;
    public TextMeshProUGUI clickCounterText;
    public Button resetButton;

    private int clickCount = 0;

    void Start()
    {

        bashButton.onClick.AddListener(OnBashButtonClick);
        resetButton.onClick.AddListener(OnResetButtonClick);
        UpdateClickCounterText();
    }

 
    void OnBashButtonClick()
    {
        clickCount++;
        UpdateClickCounterText();
    }

    void OnResetButtonClick()
    {
        clickCount = 0;
        UpdateClickCounterText();
    }

    void UpdateClickCounterText()
    {
        clickCounterText.text = "Clicks: " + clickCount.ToString();
    }
}
