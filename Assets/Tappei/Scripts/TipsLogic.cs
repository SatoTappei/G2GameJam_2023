using UnityEngine;
using UnityEngine.UI;

public class TipsLogic : MonoBehaviour
{
    [SerializeField] Button _button;
    [Header("入力可能までのディレイ")]
    [Tooltip("フェードが終わるまでの間、入力を受け付けないようにする")]
    [SerializeField] float _delay = 2.0f;

    float _timer;
    bool _already;

    void Start()
    {
        _button.onClick.AddListener(ToInGame);
    }

    void Update()
    {
        _timer += Time.deltaTime;

        // ディレイ後、一度だけ入力判定を取る
        if (Input.GetKeyDown(KeyCode.Return) && !_already && _timer > _delay)
        {
            ToInGame();
        }
    }

    void ToInGame()
    {
        _already = true;
        GameManager.SceneChange("InGame");
        AudioPlayer.Instance.PlaySE(AudioType.SE_SubmitUI);
    }
}
