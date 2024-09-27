using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public PlayerController player;
    public TMP_Text timerText;
    

    void Update()
    {
        timerText.text = "Time: " + Mathf.Ceil(player.timer).ToString();
    }
}
