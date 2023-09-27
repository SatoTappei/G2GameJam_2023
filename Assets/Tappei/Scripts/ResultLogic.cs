using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultLogic : MonoBehaviour
{
    [SerializeField] Button _titleButton;

    void Start()
    {
        _titleButton.onClick.AddListener(ToTitle);
    }

    void ToTitle()
    {
        SceneChanger.SceneChange("Title");
        AudioPlayer.Instance.PlaySE(AudioType.SE_SubmitUI);
    }

}
