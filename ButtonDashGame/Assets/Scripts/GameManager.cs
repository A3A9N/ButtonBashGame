using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI winText;

    void Start()
    {
        winText.gameObject.SetActive(false); 
    }

    void OnEnable()
    {
        FinishLineController.OnPlayerWin += HandlePlayerWin; 
    }

    void OnDisable()
    {
        FinishLineController.OnPlayerWin -= HandlePlayerWin; 
    }
    IEnumerator FadeInText()
    {
        winText.alpha = 0; // Start met volledige transparantie
        winText.gameObject.SetActive(true); // Activeer de tekst

        while (winText.alpha < 1)
        {
            winText.alpha += Time.deltaTime; // Verhoog de alpha langzaam voor een fade effect
            yield return null;
        }
    }


    void HandlePlayerWin()
    {
        GameOver(true);
    }

    void GameOver(bool didWin)
    {
        if (didWin)
        {
            StartCoroutine(FadeInText());
        }
    }
}
