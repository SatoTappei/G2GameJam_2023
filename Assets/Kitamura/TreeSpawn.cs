using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawn : MonoBehaviour
{
    [SerializeField] SpriteRenderer _tree;
    [SerializeField] Transform[] _spawn;
    BackGroundScroll _backGroundScroll;
    float timer;
    void Start()
    {
        _backGroundScroll = GameObject.Find("System").GetComponent<BackGroundScroll>();
    }
    void Update()
    {
        float gear = _backGroundScroll.ScrollSpeed;
        timer += Time.deltaTime;
        if (timer > 0.5f)
        {
            timer = 0;
            Instantiate(_tree, _spawn[Random.Range(0, 4)].position,transform.rotation);
        }
    }
}
