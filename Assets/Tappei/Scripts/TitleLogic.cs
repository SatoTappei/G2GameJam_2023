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
        GameManager.SceneChange("Tips");
        AudioPlayer.Instance.PlaySE(AudioType.SE_SubmitUI);
    }
}
