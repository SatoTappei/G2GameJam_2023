using UnityEngine;
using UnityEngine.UI;

public class TipsLogic : MonoBehaviour
{
    [SerializeField] Button _button;
    [Header("���͉\�܂ł̃f�B���C")]
    [Tooltip("�t�F�[�h���I���܂ł̊ԁA���͂��󂯕t���Ȃ��悤�ɂ���")]
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

        // �f�B���C��A��x�������͔�������
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
