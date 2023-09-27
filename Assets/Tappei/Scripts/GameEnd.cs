using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    [SerializeField] GameObject _gameClear;
    [SerializeField] GameObject _gameOver;

    void Awake()
    {
        _gameClear.SetActive(false);
        _gameOver.SetActive(false);
    }

    public void GameClear()
    {
        _gameClear.SetActive(true);
    }

    public void GameOver()
    {
        _gameOver.SetActive(true);
    }
}
