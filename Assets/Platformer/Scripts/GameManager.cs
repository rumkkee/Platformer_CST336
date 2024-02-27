using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _coinCount;
    private int _currentScore;

    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        StartCoroutine(UpdateTime());
    }

    private IEnumerator UpdateTime()
    {
        int intTime = 10;
        while(intTime >= 0)
        {
            string timeStr = $"Time \n{intTime}";
            _timerText.text = timeStr;
            yield return new WaitForSecondsRealtime(1f);
            --intTime;
        }
        Debug.Log("Your time is up, Mario.");

    }

    public void AddCoin()
    {
        ++_coinCount;
        _currentScore += 100;
        UpdateCoinDisplay(_coinCount);
        UpdateScoreDisplay(_currentScore);
    }

    private void UpdateCoinDisplay(int coinCount)
    {
        _coinText.text = $"COINS \n{coinCount}";
    }

    private void UpdateScoreDisplay(int newScore)
    {
        string scoreFormatted = newScore.ToString("0000000");
        _scoreText.text = $"MARIO \n{scoreFormatted}";
    }

    public void AddtoScore(int scoreToAdd)
    {
        _currentScore += scoreToAdd;
        UpdateScoreDisplay(_currentScore);
    }
}
