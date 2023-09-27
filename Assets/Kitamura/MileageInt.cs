using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class MileageInt : MonoBehaviour
{
    [SerializeField] Text _mileageText;
    BackGroundScroll _backGroundScroll;
    int _mileage;
    float _timer;
    public int Mileage { get => _mileage; }
    bool _flag;

    void OnEnable()
    {
        MainLogic.OnGameStart += () => _flag = true;
        MainLogic.OnGameClear += () => _flag = false;
        MainLogic.OnGameOver += () => _flag = false;
    }

    private void OnDisable()
    {
        MainLogic.OnGameStart -= () => _flag = true;
        MainLogic.OnGameClear -= () => _flag = false;
        MainLogic.OnGameOver -= () => _flag = false;
    }
    void Start()
    {
        _backGroundScroll = GetComponent<BackGroundScroll>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_flag)
        {
            _timer += Time.deltaTime;
            float scrollspeed = _backGroundScroll.ScrollSpeed;
            _mileage += (int)(scrollspeed * _timer);
            _mileageText.text = _mileage.ToString();
        }
    }
}
