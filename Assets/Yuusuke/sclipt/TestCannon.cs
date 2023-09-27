using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestCannon : MonoBehaviour
{
    [SerializeField, Header("�e�̔��ˏꏊ")] Transform _muzzle;
    [SerializeField, Header("�J���[�{�[���̃v���n�u")] GameObject[] _colorBall;
    //[SerializeField, Header("�e�̒��e�n�_")] Transform[] _ballPoint;
    //public Transform[] BallPoint => _ballPoint;

    void Start()
    {
        //�^�񒆂��E�ɏo�������獶������
        if (transform.position.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�v���C���[�����m������e������
        if (_muzzle != null && collision.CompareTag("Player"))
        {
            int ball = Random.Range(0, _colorBall.Length);
            CannonFire(ball);
        }
    }

    //�e�����֐�
    void CannonFire(int ball)
    {
        Instantiate(_colorBall[ball], _muzzle.position, _colorBall[ball].transform.rotation);
    }
}
