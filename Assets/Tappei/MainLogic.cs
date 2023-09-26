using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainLogic : MonoBehaviour
{
    [SerializeField] Button _resultButton;

    float _timer;
    float _eventTime;

    void Start()
    {
        _eventTime = Params.EventRate;

        _resultButton.onClick.AddListener(ToResult);
    }

    void Update()
    {
        if (_timer > Params.TimeLimit)
        {
            Debug.Log("Ç™ÇﬂÇ®Ç◊ÇÁ");
        }

        _timer += Time.deltaTime;
        if (_timer > _eventTime)
        {
            _eventTime += Params.EventRate;
            Debug.Log("ÉCÉxÉìÉgî≠ê∂");
        }
    }

    void ToResult()
    {
        SceneChanger.SceneChange("Result");
        AudioPlayer.Instance.PlaySE(AudioType.SE_SubmitUI);
    }
}
