using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class MileageInt : MonoBehaviour
{
    [SerializeField] Text _mileageText;
    Scroll _backGroundScroll;
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
        _backGroundScroll = GetComponent<Scroll>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_flag)
        {
            if (_timer > 1)
            {
                //_mileage += (int)_backGroundScroll.ScrollSpeed;
                //_timer = 0;
            }
        }
        _mileageText.text = _mileage.ToString();
    }
}