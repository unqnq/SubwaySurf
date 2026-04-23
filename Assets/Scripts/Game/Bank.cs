using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] TMP_Text currentCoinCountText;
    [SerializeField] int currentCoinCount = 0;

    void Awake()
    {
        currentCoinCountText = GameObject.Find("CoinText").GetComponent<TMP_Text>();
        LoadCoinCount();
        UpdateUI();
    }

    void UpdateUI()
    {
        currentCoinCountText.SetText(currentCoinCount.ToString());
    }

    void LoadCoinCount()
    {
        currentCoinCount = PlayerPrefs.GetInt("CurrentCoinCount", 0);
    }

    void SaveCoinCount()
    {
        PlayerPrefs.SetInt("CurrentCoinCount", currentCoinCount);
    }

    public void AddCoin(int amount)
    {
        currentCoinCount += amount;
        UpdateUI();
        SaveCoinCount();
    }

    public bool IsCanSpend(int amount)
    {
        if(currentCoinCount - amount >= 0)
        {
            currentCoinCount -= amount;
            UpdateUI();
            SaveCoinCount();
            return true;
        }
        return false;
    }
}
