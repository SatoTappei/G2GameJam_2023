using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Cannon : ScrollEnvironment
{
    [System.Serializable]
    class Content
    {
        public GameObject Ball;
        [Range(0, 100)]
        public int Rate;
    }

    [SerializeField] Transform _muzzle;
    [SerializeField] Content[] _balls;

    int _probabilityMax;

    protected override void OnStart()
    {
        // �m���̍ő�l
        _probabilityMax = _balls.Select(v => v.Rate).Sum();

        // x���W0�𒆐S�ɍ��E�𔻒肵�Č�����ς���
        if (transform.position.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void Spawn()
    {
        int value = Random.Range(0, _probabilityMax);
        int weight = 0;
        for (int i = 0; i < _balls.Length; i++)
        {
            weight += _balls[i].Rate;
            if (value < weight)
            {
                GameObject ball = Instantiate(_balls[i].Ball, _muzzle.position, Quaternion.identity, transform.parent);
                return;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Spawn();
        }
    }
}
