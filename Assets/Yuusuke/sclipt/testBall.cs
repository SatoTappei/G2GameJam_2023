using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class testBall : MonoBehaviour
{
    [SerializeField, Header("ボールのスピード")] float _ballSpead;
    [SerializeField, Header("大砲のプレハブ")] cannon _cannon;
    [SerializeField, Header("ボールの到達地点")] Transform[] _ballPoint;

    [SerializeField, Header("爆発エフェクト")] GameObject _effect;
    [SerializeField, Header("爆発エフェクトを表示する時間")] float _effectTime = 1f;


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
        //_startPosから_ballPoint[_random].positionまで行く。_nowPosで目標地点までを％で表す
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
        //プレイヤーか目標地点に到着したらボールを破壊してエフェクトを出す
        if (collision.CompareTag("Player"))
        {
            GameObject effect = Instantiate(_effect, this.transform.position, transform.rotation);
            Destroy(effect, _effectTime);
            Destroy(gameObject);
        }
    }
}
