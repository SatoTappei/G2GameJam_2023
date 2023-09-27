using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSpawn : MonoBehaviour
{
    [SerializeField] GameObject _cannon;
    [Header("�X�|�[���ʒu(2�܂�)")]
    [SerializeField] Transform[] _spawn = new Transform[2];
    [Header("�X�|�[���p�x(�b)")]
    [SerializeField] float _coolTime = 0;
    float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > _coolTime)
        {
            timer = 0;
            Instantiate(_cannon, _spawn[Random.Range(0, 2)].position, transform.rotation);
        }
    }
}
