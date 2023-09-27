using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSpawn : MonoBehaviour
{
    [SerializeField] GameObject _cannon;
    [Header("スポーン位置(2つまで)")]
    [SerializeField] Transform[] _spawn = new Transform[2];
    [Header("スポーン頻度(クールタイム/ギア別スピード)秒/1機")]
    [SerializeField] float _coolTime = 10;
    float timer;
    bool flag = false;
    BackGroundScroll _backGroundScroll;

    void OnEnable()
    {
        MainLogic.OnGameStart += () => flag = true;
        MainLogic.OnGameClear += () => flag = false;
    }

    private void OnDisable()
    {
        MainLogic.OnGameStart -= () => flag = true;
        MainLogic.OnGameClear -= () => flag = false;
    }

    void Start()
    {
        _backGroundScroll = GameObject.Find("System").GetComponent<BackGroundScroll>();
    }
    void Update()
    {
        float cooltime = _coolTime/_backGroundScroll.ScrollSpeed;
        if (flag)
        {
            timer += Time.deltaTime;
            if (timer > cooltime)
            {
                timer = 0;
                Instantiate(_cannon, _spawn[Random.Range(0, 2)].position, transform.rotation);
            }
        }
    }
}
