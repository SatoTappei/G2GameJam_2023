using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    [SerializeField] GameObject _gameClear;
    [SerializeField] GameObject _gameOver;
    [SerializeField] Button _retryButton;

    void Awake()
    {
        _gameClear.SetActive(false);
        _gameOver.SetActive(false);
        _retryButton.onClick.AddListener(Retry);
    }

    public void GameClear()
    {
        _gameClear.SetActive(true);
    }

    public void GameOver()
    {
        _gameOver.SetActive(true);
    }

    void Retry()
    {
        SceneChanger.SceneChange("InGame");
    }
}
