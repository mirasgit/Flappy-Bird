using UnityEngine;
using UnityEngine.InputSystem.iOS;
using TMPro;
using System;
public class Score : MonoBehaviour
{
    public static Score instance;

    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _bestScoreText;

    private int _score;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        _currentScoreText.text = _score.ToString();

        _bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        UpdateBestScore();
    }

    private void UpdateBestScore()
    {
        if (_score > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", _score);
            _bestScoreText.text = _score.ToString();
        }
    }

    public void UpdateScore()
    {
        _score++;
        _currentScoreText.text = _score.ToString();
        UpdateBestScore();
        GameEventHandler.RaiseScore();
    }

}
