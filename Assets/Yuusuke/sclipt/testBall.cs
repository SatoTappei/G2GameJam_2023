using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class testBall : MonoBehaviour
{
    [SerializeField, Header("�{�[���̃X�s�[�h")] float _ballSpead;
    [SerializeField, Header("��C�̃v���n�u")] cannon _cannon;
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
        //_startPos����_ballPoint[_random].position�܂ōs���B_nowPos�ŖڕW�n�_�܂ł����ŕ\��
        transform.position = Vector3.Lerp(_startPos, _ballPoint[_random].position, _nowPos);
        _nowPos += Time.deltaTime;
        _nowPos = Mathf.Clamp01(_nowPos);

        if (this.transform.position == _ballPoint[_random].position)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�v���C���[���ڕW�n�_�ɓ���������{�[����j�󂵂ăG�t�F�N�g���o��
        if (collision.CompareTag("Player"))
        {
            GameObject effect = Instantiate(_effect, this.transform.position, transform.rotation);
            Destroy(effect, _effectTime);
            Destroy(gameObject);
        }
    }
}
