using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField, Header("ボールのスピード")] float _ballSpead;
    [SerializeField] cannon _cannon;
    [SerializeField, Header("ボールの到達地点")] Transform[] _ballPoint;

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
        Debug.Log(_ballPoint[_random].position);
        _nowPos += Time.deltaTime;
        _nowPos = Mathf.Clamp01(_nowPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
