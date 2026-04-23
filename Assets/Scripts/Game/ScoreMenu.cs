using TMPro;
using UnityEngine;

public class ScoreMenu : Score
{
    [SerializeField] TMP_Text scoreText;

    void Awake()
    {
        LoadScore();
        UpdateUI();    
    }

    void UpdateUI()
    {
        scoreText.SetText(bestScore.ToString());
    }
}
