using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawn : MonoBehaviour
{
    [SerializeField] SpriteRenderer _tree;
    [Header("スポーン位置(4つまで)")]
    [SerializeField] Transform[] _spawn = new Transform[4];
    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.5f)
        {
            timer = 0;
            Instantiate(_tree, _spawn[Random.Range(0, 4)].position,transform.rotation);
        }
    }
}
