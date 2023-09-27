using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSpawn : MonoBehaviour
{
    [SerializeField] GameObject _cannon;
    [Header("スポーン位置(2つまで)")]
    [SerializeField] Transform[] _spawn = new Transform[2];
    [Header("スポーン頻度(秒)")]
    [SerializeField] float _coolTime = 0;
    float timer;
    bool flag = false;

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
    void Update()
    {
        if (flag)
        {
            timer += Time.deltaTime;
            if (timer > _coolTime)
            {
                timer = 0;
                Instantiate(_cannon, _spawn[Random.Range(0, 2)].position, transform.rotation);
            }
        }
    }
}
