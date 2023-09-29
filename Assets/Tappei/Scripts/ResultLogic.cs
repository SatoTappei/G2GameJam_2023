using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultLogic : MonoBehaviour
{
    [SerializeField] Button _titleButton;
    [SerializeField] Button _retryButton;
    [SerializeField] Text _text;
    [SerializeField] GameObject _clear;
    [SerializeField] GameObject _gameOver;

    void Start()
    {
        _titleButton.onClick.AddListener(ToTitle);
        _retryButton.onClick.AddListener(ToInGame);

        _text.text = GameManager.Score.ToString("F2");
        if (GameManager.ResultType == ResultType.GameClear)
        {
            AudioPlayer.Instance.PlaySE(AudioType.SE_ResultGameClear);
            _gameOver.SetActive(false);
        }
        else
        {
            AudioPlayer.Instance.PlaySE(AudioType.SE_ResultGameOver);
            _clear.SetActive(false);
        }

        Debug.Log("ç°âÒÇÃÉXÉRÉA:" + GameManager.Score);
    }

    void ToTitle()
    {
        GameManager.SceneChange("Title");
        AudioPlayer.Instance.PlaySE(AudioType.SE_SubmitUI);
    }

    void ToInGame()
    {
        GameManager.SceneChange("InGame");
        AudioPlayer.Instance.PlaySE(AudioType.SE_SubmitUI);
    }
}
