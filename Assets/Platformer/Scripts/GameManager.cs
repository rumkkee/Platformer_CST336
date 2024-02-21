using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TextMeshProUGUI _coinText;

    private int coinCount;

    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        UpdateTime();
    }

    private void UpdateTime()
    {
        int intTime = 400 - (int)Time.realtimeSinceStartup;
        string timeStr = $"Time \n{intTime}";
        _timerText.text = timeStr;
    }

    public void AddCoin()
    {
        ++coinCount;
        UpdateCoinDisplay(coinCount);
    }

    private void UpdateCoinDisplay(int coinCount)
    {
        _coinText.text = $"COINS \n{coinCount}";
    }
}
