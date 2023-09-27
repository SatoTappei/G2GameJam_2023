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

        _text.text = SceneChanger.Score.ToString();
        if (SceneChanger.IsGameOver)
        {
            _clear.SetActive(false);
        }
        else
        {
            _gameOver.SetActive(false);
        }

        Debug.Log("ç°âÒÇÃÉXÉRÉA:" + SceneChanger.Score);
    }

    void ToTitle()
    {
        SceneChanger.SceneChange("Title");
        AudioPlayer.Instance.PlaySE(AudioType.SE_SubmitUI);
    }

    void ToInGame()
    {
        SceneChanger.SceneChange("InGame");
        AudioPlayer.Instance.PlaySE(AudioType.SE_SubmitUI);
    }
}
