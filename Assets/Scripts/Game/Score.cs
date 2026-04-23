using UnityEngine;

public class Score : MonoBehaviour
{
    protected int bestScore;

    protected void LoadScore()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    protected void SaveScore()
    {
        PlayerPrefs.SetInt("BestScore", bestScore);
    }

    protected void SetNeewBestScore(int newBestScore)
    {
        if(bestScore < newBestScore)
        {
            bestScore = newBestScore;
            SaveScore();
        }
    }
}
