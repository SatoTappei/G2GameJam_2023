using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestCannon : MonoBehaviour
{
    [SerializeField, Header("弾の発射場所")] Transform _muzzle;
    [SerializeField, Header("カラーボールのプレハブ")] GameObject[] _colorBall;
    //[SerializeField, Header("弾の着弾地点")] Transform[] _ballPoint;
    //public Transform[] BallPoint => _ballPoint;

    void Start()
    {
        //真ん中より右に出現したら左を向く
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
        //プレイヤーを感知したら弾を撃つ
        if (_muzzle != null && collision.CompareTag("Player"))
        {
            int ball = Random.Range(0, _colorBall.Length);
            CannonFire(ball);
        }
    }

    //弾を撃つ関数
    void CannonFire(int ball)
    {
        Instantiate(_colorBall[ball], _muzzle.position, _colorBall[ball].transform.rotation);
    }
}
