using TMPro;
using UnityEngine;

public class ScoreCounter : Score
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] float scoreMultiplier = 2;
    [SerializeField] bool shouldCount = true;
    [SerializeField] float score;

    void Awake()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
    }
    void Count()
    {
        Debug.Log(Time.deltaTime * scoreMultiplier);
        score += Time.deltaTime * scoreMultiplier;
        scoreText.SetText($"Score: {(int)score}");
    }

    void Update()
    {
        if(!shouldCount) return;
        Count();
    }

    public void ChangeCount()
    {
        shouldCount = false;
        SetNeewBestScore((int)score);
    }
}
