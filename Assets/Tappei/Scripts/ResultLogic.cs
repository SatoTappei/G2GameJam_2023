using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultLogic : MonoBehaviour
{
    [SerializeField] Button _titleButton;
    [SerializeField] Button _retryButton;

    void Start()
    {
        _titleButton.onClick.AddListener(ToTitle);
        _retryButton.onClick.AddListener(ToInGame);
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
