using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleLogic : MonoBehaviour
{
    [SerializeField] Button _titleButton;

    void Start()
    {
        _titleButton.onClick.AddListener(ToInGame);
    }

    void ToInGame()
    {
        SceneChanger.SceneChange("InGame");
        AudioPlayer.Instance.PlaySE(AudioType.SE_SubmitUI);
    }
}
