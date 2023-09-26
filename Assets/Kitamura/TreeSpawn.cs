using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawn : MonoBehaviour
{
    [SerializeField] SpriteRenderer _tree;
    [SerializeField] Transform[] _spawn;
    BackGroundScroll _backGroundScroll;
    float _timer;
    [Header("ÉMÉAÇ≤Ç∆ÇÃÉXÉ|Å[Éìïpìx(ïb)")]
    [SerializeField] float _gearOne = 0.5f;
    [SerializeField] float _gearTwo = 0.3f;
    [SerializeField] float _gearThree = 0.1f;

    void Start()
    {
        _backGroundScroll = GameObject.Find("System").GetComponent<BackGroundScroll>();
    }
    void Update()
    {
        float gear = _backGroundScroll.ScrollSpeed;
        _timer += Time.deltaTime;
        if (gear == 1)
        {
            if (_timer > 0.5f)
            {
                _timer = 0;
                Instantiate(_tree, _spawn[Random.Range(0, 4)].position, transform.rotation);
            }
        }
        else if (gear == 2)
        {
            if (_timer > 0.5f)
            {
                _timer = 0;
                Instantiate(_tree, _spawn[Random.Range(0, 4)].position, transform.rotation);
            }
        }
    }
}
