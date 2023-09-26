using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    //Rigidbody2D rb;
    [SerializeField, Header("ボールのスピード")] float _ballSpead;
    [SerializeField] Cannon _cannon;
    [SerializeField] GameObject _cannonObject;

    bool _isLeftFire;

    int _randomPoint = 0;
    float _nowPos;
    Vector3 _startPosi;
    Vector2 v;
    Vector3 v2;
    Rigidbody2D rb;
    void Start()
    {
        //_startPosi = this.transform.position;

        _randomPoint = UnityEngine.Random.Range(0, _cannon.BallPoint.Length);
        rb = GetComponent<Rigidbody2D>();
        v2 = (_cannonObject.transform.position - _cannon.BallPoint[_randomPoint].position).normalized;
    }

    void Update()
    {
        //transform.position = Vector3.Lerp(_startPosi, _cannon.BallPoint[_randomPoint].position, _nowPos);
        //Debug.Log(_cannon.BallPoint[_randomPoint].position);
        //_nowPos += Time.deltaTime;
        //_nowPos = Mathf.Clamp01(_nowPos);

        //if(_isLeftFire)
        //{
            v = v2 * _ballSpead;
        Debug.Log(_cannon.BallPoint[_randomPoint].position);
        //}
        //else
        //{
            //v = v2 * _ballSpead;
        //}
        
       

        rb.velocity = v;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag($"point{_randomPoint + 1}"))
        {
            Destroy(gameObject);
        }
    }

    public void SetIsLeftFire(bool isLeftFire)
    {
        this._isLeftFire = isLeftFire;
    }
}
