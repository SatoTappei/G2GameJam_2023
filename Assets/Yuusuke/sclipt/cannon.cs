using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cannon : MonoBehaviour
{
    [SerializeField, Header("’e‚Ì”­ŽËêŠ")] Transform _muzzle;
    [SerializeField] GameObject[] _colorBall;
    //[SerializeField, Header("’e‚Ì’…’e’n“_")] Transform[] _ballPoint;
    //public Transform[] BallPoint => _ballPoint;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x > 0)
        {
            transform.localScale *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_muzzle != null && collision.CompareTag("Player"))
        {
            int ball = Random.Range(0, _colorBall.Length);
            CannonFire(ball);
        }
    }

    void CannonFire(int ball)
    {
        Instantiate(_colorBall[ball], _muzzle.position, _colorBall[ball].transform.rotation);
    }
}
