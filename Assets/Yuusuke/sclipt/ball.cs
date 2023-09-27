using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField, Header("�{�[���̃X�s�[�h")] float _ballSpead;
    [SerializeField] cannon _cannon;
    [SerializeField, Header("�{�[���̓��B�n�_")] Transform[] _ballPoint;

    [SerializeField, Header("�����G�t�F�N�g")] GameObject _effect;
    [SerializeField, Header("�����G�t�F�N�g��\�����鎞��")] float _effectTime = 1f;


    Vector3 _startPos;
    float _nowPos;
    int _random;


    void Start()
    {
        _startPos = this.transform.position;
        _random = Random.Range(0, _ballPoint.Length);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(_startPos,_ballPoint[_random].position , _nowPos);
        _nowPos += Time.deltaTime;
        _nowPos = Mathf.Clamp01(_nowPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject effect = Instantiate(_effect, this.transform.position, transform.rotation);
            Destroy(effect, _effectTime);
            Destroy(gameObject);
        }
        if (collision.CompareTag($"point{_random +1}"))
        {
            GameObject effect = Instantiate(_effect, this.transform.position, transform.rotation);
            Destroy(effect, _effectTime);
            Destroy(gameObject);
        }
    }
}
